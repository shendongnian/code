    string batchFileName = @"c:\batosql.bat";
    string sqlFileName = @"c:\MySqlScripts.sql";
    Process proc = new Process();
    proc.StartInfo.FileName = batchFileName;
    proc.StartInfo.Arguments = sqlFileName;
    proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
    proc.StartInfo.ErrorDialog = false;
    proc.StartInfo.WorkingDirectory = Path.GetDirectoryName(prg);
    proc.Start();
    proc.WaitForExit();
    if ( proc.ExitCode!= 0 )
