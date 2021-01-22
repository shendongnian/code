    private static void OpenNetworkConnection(string savePath, string username, string password)
        {
            var directory = Path.GetDirectoryName(savePath).Trim();
            var process = new Process
                              {
                                  StartInfo = new ProcessStartInfo
                                                  {
                                                      WindowStyle = ProcessWindowStyle.Hidden,
                                                      FileName = "cmd.exe",
                                                      Arguments =
                                                          "NET USE " + directory + " /user:" +
                                                          username +
                                                          " " + password
                                                  }
                              };
            process.Start();
            process.Close();
        }
