                            if (args != null)
                            {
                                for (int i = 0; i < args.Length; i++)
                                {
                                    if (!File.Exists(args[i]))
                                    {
                                        try
                                        {
                                            var localPath = Helper.DownloadLocally(args[i], Helper.ApplicationDirectory);
                                            args[i] = localPath.ToString(); ;
                                        }
                                        catch (Exception)
                                        {
                                            throw;
                                        }
                                    }
                               
                                }
                                foreach (var arg in args)
                                {
                                        powerShell.AddArgument(arg);
                                }
                            }
