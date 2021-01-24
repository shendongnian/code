    using System;
    using Microsoft.Management.Infrastructure;
    using Microsoft.Management.Infrastructure.Options;
    using System.Security;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    
    namespace WSManApp
    {
        public class WSManHelper
        {
            private CimCredential Credentials { get; set; }
            public WSManSessionOptions SessionOptions { get; set; }
            public CimSession SystemSession { get; set; }
            public bool Connected { get; private set; }
            public CimInstance Win32_OperatingSystem { get; set; } // Only single instance of Win32_OperatingSystem
            public List<CimInstance> Win32_Service { get; set; }
            public List<string> RegSoftwareUninstall { get; set; }
            public string WMINameSpace = @"root\cimv2";
            public string RegistryNameSpace = @"root\default";
            public string RegistryClassName = "StdRegProv";
    
    
            public WSManHelper(string ComputerName, PasswordAuthenticationMechanism AuthType, string Domain, string UserName, string Password, uint Port = 5985)
            {
                SecureString securepassword = new SecureString();
                foreach (char c in Password)
                {
                    securepassword.AppendChar(c);
                }
                ClassSetup(ComputerName, AuthType, Domain, UserName, securepassword, Port);
            }
    
            public WSManHelper(string ComputerName, PasswordAuthenticationMechanism AuthType, string Domain, string UserName, SecureString Password, uint Port = 5985)
            {
                ClassSetup(ComputerName, AuthType, Domain, UserName, Password, Port);
            }
     
            private void ClassSetup(string ComputerName, PasswordAuthenticationMechanism AuthType, string Domain, string UserName, SecureString Password, uint Port)
            {
                if (AuthType == PasswordAuthenticationMechanism.Default)
                {
                    AuthType = PasswordAuthenticationMechanism.Kerberos;
                }
                Credentials = new CimCredential(AuthType, Domain, UserName, Password);
                SessionOptions = new WSManSessionOptions() { DestinationPort = Port };
                SessionOptions.AddDestinationCredentials(Credentials);
                SystemSession = CimSession.Create(ComputerName, SessionOptions);
                Connected = SystemSession.TestConnection(out CimInstance TmpInstance, out CimException TmpExeption);
            }
    
            public void GetWMIDataFromSystem()
            {
                Win32_OperatingSystem = GetOperatingSystemInstance();
                Win32_Service = GetServiceList();
                EnumerateBaseSoftwareKeys();
            }
    
            public CimInstance GetOperatingSystemInstance()
            {
                return GetClassInstancData(WMINameSpace, "Win32_OperatingSystem");
                // for the Operating system there is only one instance so it can be referenced by setting the index to 0 for the collection.
            }
    
            public List<CimInstance> GetServiceList()
            {
                // Win32_Service
                return GetClassListData(WMINameSpace, "Win32_Service");
            }
    
            private CimInstance GetClassInstancData(string NameSpace, string ClassName)
            {
                // default query, i.e. select * from Win32_Service or select * from Win32_ComputerSystem
                return GetClassListData(NameSpace, ClassName)[0];
            }
    
            private CimInstance GetClassInstancData(string NameSpace, string ClassName, string Query)
            {
                // used for custom query
                return GetClassListData(NameSpace, ClassName, Query)[0];
            }
    
            private List<CimInstance> GetClassListData(string NameSpace, string ClassName)
            {
                return GetClassListData(NameSpace, ClassName, "SELECT * FROM " + ClassName);
            }
    
            private List<CimInstance> GetClassListData(string NameSpace, string ClassName, string Query)
            {
                List<CimInstance> cimInstances = new List<CimInstance>();
                try
                {
                    cimInstances = SystemSession.QueryInstances(NameSpace, "WQL", Query).ToList();
                }
                catch (Exception ex)
                {
                    string ErrorMsg = ex.Message;
                    // Log error :ex.Message "Error while running method GetClassListData"
                }
                return cimInstances;
            }
    
            public void EnumerateBaseSoftwareKeys()
            {
                string SubKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
                CimMethodResult CimMR = SystemSession.InvokeMethod(new CimInstance(RegistryClassName, RegistryNameSpace), "EnumKey", SetRegParameters(RegHives.LOCAL_MACHINE, RegistryMethods.EnumKey, SubKey));
                string[] RegSubKeyArray = (string[])CimMR.OutParameters["sNames"].Value;
                if (RegSubKeyArray != null)
                {
                    CheckForRegSoftware(SubKey, RegSubKeyArray);
                }
            }
    
            private void CheckForRegSoftware(string SubKey, string[] RegSubKeyArray)
            {
                foreach (var item in RegSubKeyArray)
                {
                    string TmpSubKey = SubKey + @"\" + item;
                    CimMethodResult SoftwareData = SystemSession.InvokeMethod(new CimInstance(RegistryClassName, RegistryNameSpace), "EnumValues", SetRegParameters(RegHives.LOCAL_MACHINE, RegistryMethods.EnumValues, TmpSubKey));
                    string[] SoftWareDataFields = (string[])SoftwareData.OutParameters["sNames"].Value;
                    if (SoftWareDataFields != null)
                    {
                        string DisplayName = "";
                        string DisplayVersion = "";
                        foreach (var DataField in SoftWareDataFields)
                        {
                            if (DataField == "DisplayName")
                            {
                                CimMethodResult NameResults = SystemSession.InvokeMethod(new CimInstance(RegistryClassName, RegistryNameSpace), "GetStringValue", SetRegParameters(RegHives.LOCAL_MACHINE, RegistryMethods.GetStringValue, TmpSubKey, "DisplayName"));
                                DisplayName = NameResults.OutParameters["sValue"].Value.ToString();
                            }
                            if (DataField == "DisplayVersion")
                            {
                                CimMethodResult VersionResults = SystemSession.InvokeMethod(new CimInstance(RegistryClassName, RegistryNameSpace), "GetStringValue", SetRegParameters(RegHives.LOCAL_MACHINE, RegistryMethods.GetStringValue, TmpSubKey, "DisplayVersion"));
                                DisplayVersion = VersionResults.OutParameters["sValue"].Value.ToString();
                            }
                        }
                    }
                }
            }
    
            private CimMethodParametersCollection SetRegParameters(RegHives RegistryHive, RegistryMethods RegMethod, string SubKeyPath, string AttributeName = "", string Value = "")
            {
                string StrRegMethod = Enum.GetName(typeof(RegistryMethods), RegMethod);
                CimMethodParametersCollection CimParams = GetParametersForMethod(RegistryNameSpace, RegistryClassName, StrRegMethod);
                CimParams["hDefKey"].Value = GetHiveValueFromString(RegistryHive);
                CimParams["sSubKeyName"].Value = SubKeyPath;
                if (StrRegMethod != "CreateKey" && StrRegMethod != "DeletKey" && StrRegMethod != "EnumKey" && StrRegMethod != "EnumValues" && StrRegMethod != "GetSecurityDescriptor")
                {
                    if (StrRegMethod != "CheckAccess" && StrRegMethod != "SetSecurityDescriptor")
                    {
                        CimParams["sValueName"].Value = AttributeName;
                        if (StrRegMethod == "SetStringValue" || StrRegMethod == "SetMultiStringValue" || StrRegMethod == "SetExpandedStringValue")
                        {
                            CimParams["sValue"].Value = Value;
                        }
                        else if (StrRegMethod == "SetDWORDValue" || StrRegMethod == "SetQWORDValue" || StrRegMethod == "SetBinaryValue")
                        {
                            CimParams["uValue"].Value = Value;
                        }
                    }
                    else if (StrRegMethod == "CheckAccess")
                    {
                        CimParams["uRequired"].Value = Value;
                    }
                    else if (StrRegMethod == "SetSecurityDescriptor")
                    {
                        CimParams["Descriptor"].Value = Value;
                    }
                }
                return CimParams;
            }
    
            public CimMethodParametersCollection GetParametersForMethod(string NameSpace, string ClassName, string MethodName)
            {
                // Returns all In parameters for a given method.  Note: Out parameters are not output as this will result in errors when a query is run.  
                CimMethodParametersCollection CimParams = new CimMethodParametersCollection();
                CimClass cimClass = SystemSession.GetClass(NameSpace, ClassName);
                foreach (CimMethodDeclaration CimMDItem in cimClass.CimClassMethods)
                {
                    if (CimMDItem.Name == MethodName)
                    {
                        foreach (var ParaItem in CimMDItem.Parameters)
                        {
                            bool isInParam = false;
                            foreach (var Qitem in ParaItem.Qualifiers)
                            {
                                if (Qitem.Name.ToLower() == "in")
                                {
                                    isInParam = true;
                                }
                            }
                            if (isInParam)
                            {
                                CimParams.Add(CimMethodParameter.Create(ParaItem.Name, null, ParaItem.CimType, CimFlags.In));
                            }
                        }
                    }
                }
                return CimParams;
            }
    
            private static UInt32 GetHiveValueFromString(RegHives RegistryHive)
            {
                //HKEY_CLASSES_ROOT = 2147483648 or 0x80000000
                //HKEY_CURRENT_USER = 2147483649 or 0x80000001
                //HKEY_LOCAL_MACHINE = 2147483650 or 0x80000002
                //HKEY_USERS = 2147483651 or 0x80000003
                //HKEY_CURRENT_CONFIG = 2147483653 or 0x80000005
                UInt32 TmpRegHive = 0;
                if (RegistryHive == RegHives.CLASSES_ROOT)
                {
                    TmpRegHive = 2147483648;
                }
                else if (RegistryHive == RegHives.CURRENT_USER)
                {
                    TmpRegHive = 2147483649;
                }
                else if (RegistryHive == RegHives.LOCAL_MACHINE)
                {
                    TmpRegHive = 2147483650;
                }
                else if (RegistryHive == RegHives.USERS)
                {
                    TmpRegHive = 2147483651;
                }
                else if (RegistryHive == RegHives.CURRENT_CONFIG)
                {
                    TmpRegHive = 2147483653;
                }
                return TmpRegHive;
            }
    
        }
    
        public enum RegistryMethods
        {
            CreateKey = 0,
            DeletKey = 1,
            EnumKey = 2,
            EnumValues = 3,
            GetStringValue = 4,
    
    
        }
    
        public enum RegHives
        {
               CLASSES_ROOT = 0,
               CURRENT_USER = 1,
               LOCAL_MACHINE = 2, 
               USERS = 3,
               CURRENT_CONFIG = 5
        }
    
    }
