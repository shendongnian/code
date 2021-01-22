        class HandleExecutable {
            private DataReceivedEventHandler outputHandler;
            public DataReceivedEventHandler OutputHandler
            {
                set { outputHandler = value; }
            }
            private DataReceivedEventHandler errorHandler;
            public DataReceivedEventHandler ErrorHandler
            {
                set { errorHandler = value; }
            }
            public void callExecutable(string executable, string args)
            {
                string commandLine = executable;
                string args = args;
                ProcessStartInfo psi = new ProcessStartInfo(commandLine);
                psi.UseShellExecute = false;
                psi.LoadUserProfile = false;
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardError = true;
                psi.WindowStyle = ProcessWindowStyle.Minimized;
                psi.CreateNoWindow = true;
                psi.Arguments = args;
                p = new Process();
                p.StartInfo = psi;
                try
                {
                    p.Start();
                    p.BeginOutputReadLine();
                    p.BeginErrorReadLine();
                    if (outputHandler != null) p.OutputDataReceived += outputHandler;
                    if (errorHandler != null) p.ErrorDataReceived += errorHandler;
                    p.WaitForExit();
                    p.Close();
                    p.Dispose();
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message);
                }
            }
        }
        //On another class
        void p_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            //HANDLE STDERR
            if (e.Data != null && !e.Data.Equals(""))
            {
                 if (!e.Data.Contains("Something")) {
                 }
            }
        }
        void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            //HANDLE STDOUT
            if (e.Data != null && !e.Data.Equals(""))
            {
            }
        }
        HandleExecutable he = new HandleExecutable();
        he.OutputHandler = p_OutputDataReceived;
        he.ErrorHandler = p_ErrorDataReceived;
        he.callExecutable(@"C:\java.exe","-cp foo ClassName");
