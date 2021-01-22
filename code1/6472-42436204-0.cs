    public static void ApplicationRestart(params string[] commandLine)
        {
            lock (SynchObj)
            {
                if (Assembly.GetEntryAssembly() == null)
                {
                    throw new NotSupportedException("RestartNotSupported");
                }
                if (_exiting)
                    return;
                _exiting = true;
                if (Environment.OSVersion.Version.Major < 6) return;
                bool cancelExit = true;
                try
                {
                    foreach (Form f in Application.OpenForms.OfType<Form>().ToList())
                    {
                        f.InvokeIfRequired(frm =>
                        {
                            frm.FormClosing += (sender, args) => cancelExit = args.Cancel;
                            frm.Close();
                        });
                        if (cancelExit) break;
                    }
                    if (cancelExit) return;
                    Process.Start(new ProcessStartInfo
                    {
                        UseShellExecute = true,
                        WorkingDirectory = Environment.CurrentDirectory,
                        FileName = Application.ExecutablePath,
                        Arguments = commandLine.Length > 0 ? string.Join(" ", commandLine) : string.Empty
                    });
                    Application.Exit();
                }
                finally
                {
                    _exiting = false;
                }
            }
        }
