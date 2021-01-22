        using System;
        using System.Management;
        using System.Management.Instrumentation;
        namespace ConsoleApplication1
        {
            public enum RegHive : uint
            {
                HKEY_CLASSES_ROOT = 0x80000000,
                HKEY_CURRENT_USER = 0x80000001,
                HKEY_LOCAL_MACHINE = 0x80000002,
                HKEY_USERS = 0x80000003,
                HKEY_CURRENT_CONFIG = 0x80000005
            }
            public enum RegType
            {
                REG_SZ = 1,
                REG_EXPAND_SZ,
                REG_BINARY,
                REG_DWORD,
                REG_MULTI_SZ = 7
            }
            class Program
            {
                static void Main(string[] args)
                {
                    const string strComputer = "computername";
                    ConnectionOptions options = new ConnectionOptions();
                    options.Impersonation = ImpersonationLevel.Impersonate;
                    options.EnablePrivileges = true;
                    options.Username = "username";
                    options.Password = "password";
                    ManagementScope myScope = new ManagementScope("\\\\" + strComputer + "\\root\\default", options);
                    ManagementPath mypath = new ManagementPath("StdRegProv");
                    ManagementClass mc = new ManagementClass(myScope, mypath, null);
                    object oValue = GetValue(mc, RegHive.HKEY_LOCAL_MACHINE, "SOFTWARE\\Microsoft\\Windows\\CurrentVersion", "ProgramFilesDir");
                    Console.WriteLine(oValue.ToString());
                }
                public static object GetValue(ManagementClass mc, RegHive hDefKey, string sSubKeyName, string sValueName)
                {
                    RegType rType = GetValueType(mc, hDefKey, sSubKeyName, sValueName);
                    ManagementBaseObject inParams = mc.GetMethodParameters("GetStringValue");
                    inParams["hDefKey"] = hDefKey;
                    inParams["sSubKeyName"] = sSubKeyName;
                    inParams["sValueName"] = sValueName;
                    object oValue = null;
                    switch (rType)
                    {
                        case RegType.REG_SZ:
                            ManagementBaseObject outParams = mc.InvokeMethod("GetStringValue", inParams, null);
                            if (Convert.ToUInt32(outParams["ReturnValue"]) == 0)
                            {
                                oValue = outParams["sValue"];
                            }
                            else
                            {
                                // GetStringValue call failed
                            }
                            break;
                        case RegType.REG_EXPAND_SZ:
                            outParams = mc.InvokeMethod("GetExpandedStringValue", inParams, null);
                            if (Convert.ToUInt32(outParams["ReturnValue"]) == 0)
                            {
                                oValue = outParams["sValue"];
                            }
                            else
                            {
                                // GetExpandedStringValue call failed
                            }
                            break;
                        case RegType.REG_MULTI_SZ:
                            outParams = mc.InvokeMethod("GetMultiStringValue", inParams, null);
                            if (Convert.ToUInt32(outParams["ReturnValue"]) == 0)
                            {
                                oValue = outParams["sValue"];
                            }
                            else
                            {
                                // GetMultiStringValue call failed
                            }
                            break;
                        case RegType.REG_DWORD:
                            outParams = mc.InvokeMethod("GetDWORDValue", inParams, null);
                            if (Convert.ToUInt32(outParams["ReturnValue"]) == 0)
                            {
                                oValue = outParams["uValue"];
                            }
                            else
                            {
                                // GetDWORDValue call failed
                            }
                            break;
                        case RegType.REG_BINARY:
                            outParams = mc.InvokeMethod("GetBinaryValue", inParams, null);
                            if (Convert.ToUInt32(outParams["ReturnValue"]) == 0)
                            {
                                oValue = outParams["uValue"] as byte[];
                            }
                            else
                            {
                                // GetBinaryValue call failed
                            }
                            break;
                    }
                    return oValue;
                }
                public static RegType GetValueType(ManagementClass mc, RegHive hDefKey, string sSubKeyName, string sValueName)
                {
                    ManagementBaseObject inParams = mc.GetMethodParameters("EnumValues");
                    inParams["hDefKey"] = hDefKey;
                    inParams["sSubKeyName"] = sSubKeyName;
                    ManagementBaseObject outParams = mc.InvokeMethod("EnumValues", inParams, null);
                    if (Convert.ToUInt32(outParams["ReturnValue"]) == 0)
                    {
                        string[] sNames = outParams["sNames"] as String[];
                        int[] iTypes = outParams["Types"] as int[];
                        for (int i = 0; i < sNames.Length; i++)
                        {
                            if (sNames[i] == sValueName)
                            {
                                return (RegType)iTypes[i];
                            }
                        }
                        // value not found
                    }
                    else
                    {
                        // EnumValues call failed
                    }
                }
            }
        }
