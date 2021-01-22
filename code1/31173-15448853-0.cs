    class Program {
      [DllImport("kernel32.dll", EntryPoint = "GetConsoleWindow")]
      private static extern IntPtr _GetConsoleWindow();
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main(string[] args) {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        /*
         * This works as following:
         * First we look for command line parameters and if there are any of them present, we run the CLI version.
         * If there are no parameters, we try to find out if we are run inside a console and if so, we spawn a new copy of ourselves without a console.
         * If there is no console at all, we show the GUI.
         * We make an exception if we find out, that we're running inside visual studio to allow for easier debugging the GUI part.
         * This way we're both a CLI and a GUI.
         */
        if (args != null && args.Length > 0) {
          // execute CLI - at least this is what I call, passing the given args.
          // Change this call to match your program.
          CLI.ParseCommandLineArguments(args);
        } else {
          var consoleHandle = _GetConsoleWindow();
          // run GUI
          if (consoleHandle == IntPtr.Zero || AppDomain.CurrentDomain.FriendlyName.Contains(".vshost"))
            // we either have no console window or we're started from within visual studio
            // This is the form I usually run. Change it to match your code.
            Application.Run(new MainForm());
          else {
            // we found a console attached to us, so restart ourselves without one
            Process.Start(new ProcessStartInfo(Assembly.GetEntryAssembly().Location) {
              CreateNoWindow = true,
              UseShellExecute = false
            });
          }
        }
      }
