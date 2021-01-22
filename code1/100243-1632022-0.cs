        static void Main(string[] args)
        {
            if (NeedElevation(args) && Elevate(args))
            { // If elevastion succeeded then quit.
                return;
            }
            // your code here
        }
        public static bool Elevate(string[] args)
        {
            try
            {
                ProcessStartInfo info = Process.GetCurrentProcess().StartInfo;
                info.Verb = "runas";
                info.Arguments = NoElevateArgument;
                foreach (string arg in args)
                {
                    info.Arguments += ' ' + arg;
                }
                info.FileName = Assembly.GetEntryAssembly().Location;
                Process process = new System.Diagnostics.Process();
                process.StartInfo = info;
                
                process.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("You don't have administrative privileges thus the Automatic Application Updates cannot be started. But the rest of application is available as usually.",
                    "Not enough user rights", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
