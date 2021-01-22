                Process proc = new Process();
                try
                {
                    proc.StartInfo.FileName = "reg.exe";
                    proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    proc.StartInfo.CreateNoWindow = true;
                    proc.StartInfo.UseShellExecute = false;
                    string command = "import " + path;
                    proc.StartInfo.Arguments = command;
                    proc.Start();
                    proc.WaitForExit();
                }
                catch (System.Exception)
                {
                    proc.Dispose();
                }
