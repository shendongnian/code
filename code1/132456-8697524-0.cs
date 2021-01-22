            ProcessStartInfo info = new ProcessStartInfo("netsh", "wlan show interfaces");
            info.WorkingDirectory = @"%WINDIR%\system32";
            info.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            info.CreateNoWindow = true;
            info.RedirectStandardOutput = true;
            info.UseShellExecute = false;
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = info;
            proc.Start();
