    public partial class App : Application
    {
        public App()
        {
            this.Exit += (s, e) =>
                {
                    System.Diagnostics.Process p = new System.Diagnostics.Process();
                    p.StartInfo = new System.Diagnostics.ProcessStartInfo("notepad.exe");
                    p.Start();
                };
        }
    }
