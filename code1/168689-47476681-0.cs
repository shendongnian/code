    proc.StartInfo.FileName = exportPath + @"\" + fileExe;
    proc.Exited += new EventHandler(myProcess_Exited);
    proc.Start();
    (...)
    
    private void myProcess_Exited(object sender, System.EventArgs e)
            {
    
                inProcess = false;
                Console.WriteLine("Exit time:    {0}\r\n" +
                    "Exit code:    {1}\r\n", proc.ExitTime, proc.ExitCode);
            }
