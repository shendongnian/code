        private static void RelaunchWithAdministratorRights(string[] args)
        {
            // Launch as administrator
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.UseShellExecute = true;
            processStartInfo.WorkingDirectory = Environment.CurrentDirectory;
            string executablePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            processStartInfo.FileName = executablePath;
            processStartInfo.Verb = "runas";
            if (args != null && args.Count() > 0)
            {
                string arguments = args[0];
                for (int i = 1; i < args.Count(); i++)
                    arguments += " " + args[i];
                processStartInfo.Arguments = arguments;
            }
            try
            {
                using (Process exeProcess = Process.Start(processStartInfo))
                {
                    exeProcess.WaitForExit();
                }
            }
            catch
            {
                // The user refused to allow privileges elevation. Do nothing and return directly ...
            }
            Environment.Exit(0);
        }
