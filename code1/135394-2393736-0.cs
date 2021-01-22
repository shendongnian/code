      static class Program {
        [STAThread]
        static void Main() {
          Application.EnableVisualStyles();
          Application.SetCompatibleTextRenderingDefault(false);
    #if DEBUG
          CreateConsole();
    #endif
          Application.Run(new Form1());
        }
    
        static void CreateConsole() {
          var t = new System.Threading.Thread(() => {
            AllocConsole();
            for (; ; ) {
              var cmd = Console.ReadLine();
              if (cmd.ToLower() == "quit") break;
              // Etc...
            }
            FreeConsole();
          });
          t.IsBackground = true;
          t.Start();
        }
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AllocConsole();
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool FreeConsole();
      }
