                       Process proc = new Process();                                                     ProcessStartInfo info = new ProcessStartInfo("Your Process name", "Arguments");`                          info.WindowStyle = ProcessWindowStyle.Hidden; 
                       info.UseShellExecute =true;
                       
                        info.Verb ="runas";
                        proc.StartInfo = info;
                        proc.Start();
