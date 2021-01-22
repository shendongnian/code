        void runScript()
        {
            using (Process p = new Process())
            {
                ProcessStartInfo info = new ProcessStartInfo("ruby C:\rubyscript.rb");
                info.Arguments = "args"; // set args
                info.RedirectStandardInput = true;
                info.RedirectStandardOutput = true;
                info.UseShellExecute = false;
                p.StartInfo = info;
                p.Start();
                string output = p.StandardOutput.ReadToEnd();
                // process output
            }
        }
