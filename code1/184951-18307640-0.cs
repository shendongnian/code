            static bool StartedFromGui = !Console.IsOutputRedirected
                                      && !Console.IsInputRedirected
                                      && !Console.IsErrorRedirected
                                      && Environment.UserInteractive
                                      && Environment.CurrentDirectory == System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location)
                                      && Console.CursorTop == 0 && Console.CursorLeft == 0
                                      && Console.Title == Environment.GetCommandLineArgs()[0]
                                      && Environment.GetCommandLineArgs()[0] == System.Reflection.Assembly.GetEntryAssembly().Location;
