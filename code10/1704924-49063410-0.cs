    try
      {
                        using (Process p = new Process())
                        {
                            // set start info
                            p.StartInfo = new ProcessStartInfo("cmd.exe")
                            {
                                // RedirectStandardInput = true,
                                // UseShellExecute = false,
                                //WorkingDirectory = root + @"\Test"
                            };
    
                            // start process
                            p.Start();
                            p.WaitForExit();
                            p.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
