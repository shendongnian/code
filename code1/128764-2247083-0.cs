        public static void Compress(FileInfo fi)
        {
            System.Diagnostics.Process process;
            process = new System.Diagnostics.Process();
            process.EnableRaisingEvents = true;
            string cmd = string.Format(@"/C ""c:\program files\winzip\WINZIP32.EXE"" -min -a {0} {1}", "C:\\testzipit\\q", fi.FullName  );
            System.Diagnostics.Process.Start("CMD.exe", cmd);
            process.Close();
        }
