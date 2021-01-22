    public static ManagementObject GetWebServerSettingsByServerComment(string serverComment)
            {
                ManagementObject returnValue = null;
    
                ManagementScope iisScope = new ManagementScope(@"\\localhost\root\MicrosoftIISv2", new ConnectionOptions());
                iisScope.Connect();
                if (iisScope.IsConnected)
                {
                    ObjectQuery settingQuery = new ObjectQuery(String.Format(
                        "Select * from IIsWebServerSetting where ServerComment = '{0}'", serverComment));
    
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher(iisScope, settingQuery);
                    ManagementObjectCollection results = searcher.Get();
    
                    if (results.Count > 0)
                    {
                        foreach (ManagementObject manObj in results)
                        {
                            returnValue = manObj;
    
                            if (returnValue != null)
                            {
                                break;
                            }
                        }
                    }
                }
    
                return returnValue;
            }
