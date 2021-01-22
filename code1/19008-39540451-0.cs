    ImpersonationHelper.Impersonate(domain, userName, userPassword, delegate
                                {
                                    //Your code here 
                                    //Let's say file copy:
                                    if (!File.Exists(to))
                                    {
                                        File.Copy(from, to);
                                    }
                                });
