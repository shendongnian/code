        public static void EditRegistryKey(string fullKeyName, string subKeyName, 
                                           string keyName, object keyValue, RegistryValueKind keyKind)
                    {
                        if (Registry.GetValue(fullKeyName, keyName, null) != null)
                        {
                            try
                            {
                                RegistryKey myKey = Registry.LocalMachine.OpenSubKey(subKeyName, true);
                                if (myKey != null)
                                {
                                    myKey.SetValue(keyName, keyValue, keyKind);
                                    myKey.Close();
                                }
                            }
                            catch (Exception ex)
                            {
                                Trace.TraceInformation(ex.Message);
                                Console.WriteLine(ex.Message);
                            }
                        }
                    }
        
   
     EditRegistryKey(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\W32Time\Config",
                            @"SYSTEM\CurrentControlSet\Services\W32Time\Config",
                            "MaxPosPhaseCorrection",
                            Convert.ToInt32("ffffffff", 16),
                            RegistryValueKind.DWord);
                
                            //Set syncronization to NTP server
        EditRegistryKey(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\W32Time\Parameters",
                        @"SYSTEM\CurrentControlSet\Services\W32Time\Parameters",
                        "Type",
                        "NTP",
                        RegistryValueKind.String);
