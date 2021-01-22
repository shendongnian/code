    private static void OpenNetworkConnection(string savePath)
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
                                                          Properties.Settings.Default.NetworkUsername.Trim() +
                                                          " " + Properties.Settings.Default.NetworkPassword.Trim()
                                                  }
                              };
            process.Start();
            process.Close();
        }
