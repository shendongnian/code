                Thread now = new Thread(() =>
                {
                    Thread.Sleep(2000); 
                    // string nu = GetActiveWindowTitle();
                    SendKeys.SendWait("{Tab}");
                    SendKeys.SendWait("{Tab}");
                    SendKeys.SendWait("{Tab}");
                    SendKeys.SendWait("{Enter}"); 
                    Thread.Sleep(4000); 
                    // now create filename path
                    string filepath=@"c:\download\thisdownloadfilehere.pdf"
                    SendKeys.SendWait(filepath); 
                    SendKeys.SendWait("{Tab}");
                    SendKeys.SendWait("{Tab}");
                    SendKeys.SendWait("{Tab}");
                    SendKeys.SendWait("{Enter}");
                      
                });
                now.Start(); 
