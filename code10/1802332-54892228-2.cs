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
        public class WSManHelper2
        {
            private CimCredential Credentials { get; set; }
            public WSManSessionOptions SessionOptions { get; set; }
            public CimSession SystemSession { get; set; }
            public PasswordAuthenticationMechanism AuthType { get; set; }
            public bool Connected { get; set; }
            public CimException Err { get; set; }
            public string ConnectionStatuMessage { get; set; }
            public CimInstance Win32_OperatingSystem { get; set; } // Only single instance of Win32_OperatingSystem
            public CimInstance Win32_ComputerSystem { get; set; } // Only single instance of Win32_ComputerSystem
            public List<CimInstance> Win32_Processor { get; set; }
            public List<CimInstance> Win32_DiskDrive { get; set; }
            public List<CimInstance> Win32_LogicalDisk { get; set; }
            public List<CimInstance> Win32_Service { get; set; }
            public List<CimInstance> Win32_GroupUser { get; set; }
            public List<CimInstance> Win32_UserAccount { get; set; }
            public List<string> RegSoftwareUninstall { get; set; }
            public List<RegAppClass2> RegAppUninstallList { get; set; }
            public string WMINameSpace = @"root\cimv2";
            public string RegistryNameSpace = @"root\default";
            public string RegistryClassName = "StdRegProv";
    
            public WSManHelper2()
            {
                // usually this is used if your changing authentication type.
            }
    
            public WSManHelper2(string ComputerName, string Domain, string UserName, string Password, uint Port = 5985)
            {
                SecureString securepassword = new SecureString();
                foreach (char c in Password)
                {
                    securepassword.AppendChar(c);
                }
                ClassSetup(ComputerName, Domain, UserName, securepassword, Port);
            }
    
            public WSManHelper2(string ComputerName, string Domain, string UserName, SecureString Password, uint Port = 5985)
            {
                ClassSetup(ComputerName, Domain, UserName, Password, Port);
            }
            public WSManHelper2(string ComputerName, string Domain, string UserName, string Password, DComSessionOptions Options)
            {
                SecureString securepassword = new SecureString();
                foreach (char c in Password)
                {
                    securepassword.AppendChar(c);
                }
                ClassSetup(ComputerName, Domain, UserName, securepassword, Options);
            }
    
            public WSManHelper2(string ComputerName, string Domain, string UserName, SecureString Password, DComSessionOptions Options)
            {
                ClassSetup(ComputerName, Domain, UserName, Password, Options);
            }
    
            public void WSManHelperManualSetup(string ComputerName, string Domain, string UserName, string Password, uint Port = 5985)
            {
                SecureString securepassword = new SecureString();
                foreach (char c in Password)
                {
                    securepassword.AppendChar(c);
                }
                ClassSetup(ComputerName, Domain, UserName, securepassword, Port);
            }
    
            private void ClassSetup(string ComputerName, string Domain, string UserName, SecureString Password, uint Port)
            {
                if (AuthType == PasswordAuthenticationMechanism.Default)
                {
                    AuthType = PasswordAuthenticationMechanism.Kerberos;
                }
                Credentials = new CimCredential(AuthType, Domain, UserName, Password);
                SessionOptions = new WSManSessionOptions() { DestinationPort = Port };
                SessionOptions.AddDestinationCredentials(Credentials);
                SystemSession = CimSession.Create(ComputerName, SessionOptions);
                if (PortTest(ComputerName))
                {
                    Connected = SystemSession.TestConnection(out CimInstance TmpInstance, out CimException TmpExeption);
                    if (!Connected)
                    {
                        Err = TmpExeption;
                        ConnectionStatuMessage = Err.Message;
                    }
                    else
                    {
                        ConnectionStatuMessage = "Connected";
                    }
                }
                else
                {
                    Connected = false;
                    ConnectionStatuMessage = "Port not open on host";
                }
                RegSoftwareUninstall = new List<string>();
            }
    
            private void ClassSetup(string ComputerName, string Domain, string UserName, SecureString Password, DComSessionOptions Options)
            {
                if (AuthType == PasswordAuthenticationMechanism.Default)
                {
                    AuthType = PasswordAuthenticationMechanism.Kerberos;
                }
                Credentials = new CimCredential(AuthType, Domain, UserName, Password);
                Options.AddDestinationCredentials(Credentials);
                SystemSession = CimSession.Create(ComputerName, SessionOptions);
                if (PortTest(ComputerName))
                {
                    Connected = SystemSession.TestConnection(out CimInstance TmpInstance, out CimException TmpExeption);
                    if (!Connected)
                    {
                        Err = TmpExeption;
                        ConnectionStatuMessage = Err.Message;
                    }
                    else
                    {
                        ConnectionStatuMessage = "Connected";
                    }
                }
                else
                {
                    Connected = false;
                    ConnectionStatuMessage = "Port not open on host";
                }
                RegSoftwareUninstall = new List<string>();
            }
    
            public void GetWMIDataFromSystem()
            {
                Win32_OperatingSystem = GetOperatingSystemInstance();
                Win32_ComputerSystem = GetComputerSystemInstance();
                Win32_Processor = GetProcessorList();
                Win32_DiskDrive = GetDiskDriveList();
                Win32_LogicalDisk = GetLogicalDisk();
                Win32_Service = GetServiceList();
                Win32_GroupUser = GetGroupUserList();
                Win32_UserAccount = GetUserAccountList();
                EnumerateBaseSoftwareKeys();
    
            }
    
            public CimInstance GetOperatingSystemInstance()
            {
                return GetClassInstancData(WMINameSpace, "Win32_OperatingSystem");
                // for the Operating system there is only one instance so it can be referenced by setting the index to 0 for the collection.
            }
    
            public CimInstance GetComputerSystemInstance()
            {
                // Win32_ComputerSystem
                // This class gets all the computer system data.  
                // Note: using WSMan to get all data, i.e. (Select * from Win32_ComputerSystem), will return an error because of the size of data returned.
                //       The issue is with the size of one property, i.e. OEMLogoBitmap.  
                //       If you increase the MaxEnvelopeSizekb of your connection properties from 500 to 5000 then all the data will be returned.
                //       This setting needs to be done on each system your getting data from.  
                // The following URL describes this issue in more detail: https://jdhitsolutions.com/blog/powershell/5931/a-powershell-mystery/ 
                // To get data we select only the rows we want to get data for, so we don't run into the MaxEnvelopeSizekb issue.
                // To get all data with "select * from Win32_ComputerSystem" you'll need to run the command "winrm set winrm/config @{MaxEnvelopeSizekb="8192"" 
                // on the server you want to get data from to modify the property MaxEnvelopeSizeKB.  To see the current amount run "winrm g winrm/config"
                string CSQuery = "Select Caption, Description, InstallDate, Name, Status, CreationClassName, NameFormat, PrimaryOwnerContact, PrimaryOwnerName, Roles, InitialLoadInfo, " +
                    "LastLoadInfo, CurrentTimeZone, DaylightInEffect, DNSHostName, Domain, DomainRole, EnableDaylightSavingsTime, Manufacturer, Model, NumberOfLogicalProcessors, " +
                    "NumberOfProcessors, PCSystemType, PowerSupplyState, SupportContactDescription, SystemType, TotalPhysicalMemory from Win32_ComputerSystem";
                return GetClassInstancData(WMINameSpace, "Win32_ComputerSystem", CSQuery);
            }
    
            public List<CimInstance> GetProcessorList(string ProcessorIDQuery = "")
            {
                // Win32_Processor
                // This class gets the properties for a given processor core.  Using the data from one process you can determine all other processors.
                return GetClassListData(WMINameSpace, "Win32_Processor");
            }
    
            public List<CimInstance> GetDiskDriveList()
            {
                // Win32_DiskDrive
                return GetClassListData(WMINameSpace, "Win32_DiskDrive");
            }
    
            private List<CimInstance> GetLogicalDisk()
            {
                // Win32_LogicalDisk
                return GetClassListData(WMINameSpace, "Win32_LogicalDisk");
            }
    
            public List<CimInstance> GetServiceList()
            {
                // Win32_Service
                return GetClassListData(WMINameSpace, "Win32_Service");
            }
    
            public List<CimInstance> GetGroupUserList()
            {
                // Win32_GroupUser
                // This Class gets all the local groups members for a system  
                return GetClassListData(WMINameSpace, "Win32_GroupUser");
            }
    
            public List<CimInstance> GetUserAccountList()
            {
                // Win32_GroupUser
                // This Class gets all the local users for a system  
                return GetClassListData(WMINameSpace, "Win32_GroupUser");
            }
    
            private CimInstance GetClassInstancData(string NameSpace, string ClassName)
            {
                return GetClassListData(NameSpace, ClassName)[0];
            }
            private CimInstance GetClassInstancData(string NameSpace, string ClassName, string Query)
            {
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
                    // Log error :ex.Message "Error while running method GetClassListData"
                }
                return cimInstances;
            }
            public void EnumerateBaseSoftwareKeys()
            {
                string SubKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
                CimMethodResult CimMR = SystemSession.InvokeMethod(new CimInstance(RegistryClassName, RegistryNameSpace), "EnumKey", SetRegParameters(RegHive.LOCAL_MACHINE, RegistryMethods.EnumKey, SubKey));
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
                    CimMethodResult SoftwareData = SystemSession.InvokeMethod(new CimInstance(RegistryClassName, RegistryNameSpace), "EnumValues", SetRegParameters(RegHive.LOCAL_MACHINE, RegistryMethods.EnumValues, TmpSubKey));
                    string[] SoftWareDataFields = (string[])SoftwareData.OutParameters["sNames"].Value;
                    if (SoftWareDataFields != null)
                    {
                        string DisplayName = "";
                        string DisplayVersion = "";
                        foreach (var DataField in SoftWareDataFields)
                        {
                            if (DataField == "DisplayName")
                            {
                                CimMethodResult NameResults = SystemSession.InvokeMethod(new CimInstance(RegistryClassName, RegistryNameSpace), "GetStringValue", SetRegParameters(RegHive.LOCAL_MACHINE, RegistryMethods.GetStringValue, TmpSubKey, "DisplayName"));
                                DisplayName = NameResults.OutParameters["sValue"].Value.ToString();
                            }
                            if (DataField == "DisplayVersion")
                            {
                                CimMethodResult VersionResults = SystemSession.InvokeMethod(new CimInstance(RegistryClassName, RegistryNameSpace), "GetStringValue", SetRegParameters(RegHive.LOCAL_MACHINE, RegistryMethods.GetStringValue, TmpSubKey, "DisplayVersion"));
                                DisplayVersion = VersionResults.OutParameters["sValue"].Value.ToString();
                            }
                        }
                        if (DisplayName != "")
                        {
                            // Create Software Item on server for enumeration
                            RegAppClass2 RAC = new RegAppClass2();
                            RAC.SubKeyPath = TmpSubKey;
                            RAC.DisplayName = DisplayName;
                            RAC.DisplayVersion = DisplayVersion;
                            RegAppUninstallList.Add(RAC);
                        }
                    }
                    RegSoftwareUninstall.Add(item);
                }
            }
    
            private CimMethodParametersCollection SetRegParameters(RegHive RegistryHive, RegistryMethods RegMethod, string SubKeyPath, string AttributeName = "", string Value = "")
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
    
            private static UInt32 GetHiveValueFromString(RegHive RegistryHive)
            {
                //HKEY_CLASSES_ROOT = 2147483648 or 0x80000000
                //HKEY_CURRENT_USER = 2147483649 or 0x80000001
                //HKEY_LOCAL_MACHINE = 2147483650 or 0x80000002
                //HKEY_USERS = 2147483651 or 0x80000003
                //HKEY_CURRENT_CONFIG = 2147483653 or 0x80000005
                UInt32 TmpRegHive = 0;
                if (RegistryHive == RegHive.CLASSES_ROOT)
                {
                    TmpRegHive = 2147483648;
                }
                else if (RegistryHive == RegHive.CURRENT_USER)
                {
                    TmpRegHive = 2147483649;
                }
                else if (RegistryHive == RegHive.LOCAL_MACHINE)
                {
                    TmpRegHive = 2147483650;
                }
                else if (RegistryHive == RegHive.USERS)
                {
                    TmpRegHive = 2147483651;
                }
                else if (RegistryHive == RegHive.CURRENT_CONFIG)
                {
                    TmpRegHive = 2147483653;
                }
                return TmpRegHive;
            }
    
            public bool PortTest(string SystemName)
            {
                bool ReturnValue = false;
                //TODO:  Get list of domains from DB then loop through each connection type.  
                IPAddress[] DNSIP;
                try
                {
                    DNSIP = Dns.GetHostAddresses(SystemName);
                    if (PortChecker(DNSIP[0], 5985)) // Port 6503 = BoKS Clntd 
                    {
                        ReturnValue = true;
                    }
                }
                catch (Exception)
                {
    
                }
                return ReturnValue;
            }
    
            private bool PortChecker(IPAddress IPAddress, int PortNumber)
            {
                bool ReturnValue = false;
                try
                {
                    using (TcpClient client = new TcpClient())
                    {
                        var result = client.BeginConnect(IPAddress, PortNumber, null, null);
                        var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromMilliseconds(300));
                        if (!success)
                        {
                            throw new Exception("Failed to connect.");  // Throw exception to exit client connection / using statement.
                        }
                        // we have connected
                        ReturnValue = true;
                        client.EndConnect(result);
                    }
                }
                catch (Exception)
                {
                    ReturnValue = false;
                }
                return ReturnValue;
            }
        }
    
    
        public class RegAppClass2 : System.IEquatable<RegAppClass2>
        {
            public string SubKeyPath { get; set; } // Example:  SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\<KeyName>
            public string DisplayName { get; set; } // The name of the software you are enumerating.
            public string DisplayVersion { get; set; } // The version of the software.
    
            public override bool Equals(object obj)
            {
                return Equals(obj as RegAppClass2);
            }
    
            public bool Equals(RegAppClass2 other)
            {
                return other != null &&
                       SubKeyPath == other.SubKeyPath &&
                       DisplayName == other.DisplayName &&
                       DisplayVersion == other.DisplayVersion;
            }
    
            public override int GetHashCode()
            {
                var hashCode = 268647240;
                hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(SubKeyPath);
                hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DisplayName);
                hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DisplayVersion);
                return hashCode;
            }
        }
        
    }
