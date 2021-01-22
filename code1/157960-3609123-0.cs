    var client = new SvnClient();
    
    System.Collections.ObjectModel.Collection<SvnLogEventArgs> logEventArgs;
                            
    client.GetLog("targetPath", out logEventArgs);
