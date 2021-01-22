     private static void CloseNetworkConnection(string savePath)
        {
            var directory = Path.GetDirectoryName(savePath).Trim();
            var process = new Process
                              {
                                  StartInfo = new ProcessStartInfo
                                                  {
                                                      WindowStyle = ProcessWindowStyle.Hidden,
                                                      FileName = "cmd.exe",
                                                      Arguments = "NET USE " +
                                                                  directory +
                                                                  " /delete"
                                                  }
                              };
            process.Start();
            process.Close();
        }
