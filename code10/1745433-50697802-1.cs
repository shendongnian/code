     var process = new Process
                              {
                                  StartInfo =
                                      {
                                          FileName = string.Concat(strCurrentPath, "\\Test\\", "CSV.exe"),
                                          RedirectStandardInput = true,
                                          RedirectStandardError = true,
                                          RedirectStandardOutput = true,
                                          UseShellExecute = false,
                                          CreateNoWindow = true,
                                          ErrorDialog = false
                                      }
                              };
    
    
            process.EnableRaisingEvents = false;
    
            process.Start();
    
            var standardInput = process.StandardInput;
            standardInput.AutoFlush = true;
            var standardOutput = process.StandardOutput;
            var standardError = process.StandardError;
    
            standardInput.Write(@"C:\Pankaj\Office\ML\Projects\Stampdocuments\DDR041");
            standardInput.Close(); // <-- output doesn't arrive before after this line
            var outputData = standardOutput.ReadLine();
    
            process.Close();
            process.Dispose();
