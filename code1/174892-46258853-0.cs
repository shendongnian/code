    string sProcessName = "firefox";
    
                if (driver.Capabilities.BrowserName == sProcessName)
                {
                    // Special fix for firefox because of issue https://github.com/mozilla/geckodriver/issues/173
                    // Kills all firefox processes
    
                    Process[] oProccesses = null;
                    bool bFound = true;
    
                    while (bFound == true)
                    {
                        bFound = false;
                        oProccesses = System.Diagnostics.Process.GetProcessesByName(sProcessName);
    
                        foreach (Process oCurrentProcess in oProccesses)
                        {
                            bFound = true;
                            //oCurrentProcess.Kill();
    
    
                            int waitTimeSecs = 2;
    
                            bool cleanExit = oCurrentProcess.WaitForExit(waitTimeSecs * 1000);
                            if (!oCurrentProcess.HasExited)
                            {
                                oCurrentProcess.CloseMainWindow();
                                System.Threading.Thread.Sleep(2000);
                            }
    
                            if (!oCurrentProcess.HasExited)
                            {
                                oCurrentProcess.Kill();
                                oCurrentProcess.WaitForExit();
                                // if an exception window has popped up, that needs to be killed too
                                
                                foreach (var process in Process.GetProcessesByName("firefox"))
                                {
                                    process.CloseMainWindow();
                                    System.Threading.Thread.Sleep(2000);
                                    if (!process.HasExited)
                                        process.Kill();
                                }
                            }
    
    
                        }
                    }
                    driver.Quit();
                }
