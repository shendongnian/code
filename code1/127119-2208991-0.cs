            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = @"C:\LAME\LAME.exe";
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.UseShellExecute = false;
            proc.Start();
            string output = proc.StandardError.ReadToEnd();
            proc.WaitForExit();
            MessageBox.Show(output);
