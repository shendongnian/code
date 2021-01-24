       var instances = GetLocalDBInstances();
       var connString= string.Format("Data Source= (LocalDB)\\{0};AttachDbFilename=|DataDirectory|\\myDB.mdf;Integrated Security=True;",instances[0]);
    
     internal static List<string> GetLocalDBInstances()
            {
                // Start the child process.
                Process p = new Process();
                // Redirect the output stream of the child process.
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.Arguments = "/C sqllocaldb info";
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                p.Start();
                // Do not wait for the child process to exit before
                // reading to the end of its redirected stream.
                // p.WaitForExit();
                // Read the output stream first and then wait.
                string sOutput = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
    
                //If LocalDb is not installed then it will return that 'sqllocaldb' is not recognized as an internal or external command operable program or batch file.
                if (sOutput == null || sOutput.Trim().Length == 0 || sOutput.Contains("not recognized"))
                    return null;
                string[] instances = sOutput.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                List<string> lstInstances = new List<string>();
                foreach (var item in instances)
                {
                    if (item.Trim().Length > 0)
                        lstInstances.Add(item);
                }
                return lstInstances;
            }
