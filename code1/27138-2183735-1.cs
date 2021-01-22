    try
    {
        string AppPath = "\\\\spri11U1118\\SampleBatch\\Bin\\";
        string strFilePath = AppPath + "ABCED120D_XXX.bat";
        System.Diagnostics.Process proc = new System.Diagnostics.Process();
    
        proc.StartInfo.FileName = strFilePath;
        string pwd = "s44erver";
    
        proc.StartInfo.Domain = "abcd";
        proc.StartInfo.UserName = "sysfaomyulm";
    
        System.Security.SecureString secret = new System.Security.SecureString();
        foreach (char c in pwd)
    
            secret.AppendChar(c);
    
        proc.StartInfo.Password = secret;
        proc.StartInfo.UseShellExecute = false;
    
        proc.StartInfo.WorkingDirectory = "psexec \\\\spri11U1118\\SampleBatch\\Bin ";
    
        proc.Start();
        while (!proc.HasExited)
        {
            proc.Refresh();
            // Thread.Sleep(1000);
        }
    
        proc.Close();
    }
    catch (Exception ex)
    {
        throw ex;
    }
