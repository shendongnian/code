            if (IntPtr.Size == 4)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                // etc...
            }
            else
            {
                // Launch application in 32-bit mode
                System.Diagnostics.Process.Start(Path.GetDirectoryName(Application.ExecutablePath) + @"\Your32BitApplicationLauncher.exe");
            }
