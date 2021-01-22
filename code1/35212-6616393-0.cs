     Process[] processlist = Process.GetProcesses();
     string theProcessThatISeekIs = "";
                    foreach (Process theprocess in processlist)  
                    {
                        if (theprocess.ProcessName.ToString().ToLower() == NameOfTheProcessYouSeek.ToLower())
                        {
                           
                            theProcessThatISeekIs = theprocess.ProcessName.ToString();
                            break;
                        }
                    }
