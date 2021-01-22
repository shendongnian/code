            // Detect existing instances
            string processName = Process.GetCurrentProcess().ProcessName;
            Process[] instances = Process.GetProcessesByName(processName);
            if (instances.Length > 1)
            {
                MessageBox.Show("Only one running instance of application is allowed");
                Process.GetCurrentProcess().Kill();
                return;
            }
            // End of detection
