    using (var p = new System.Diagnostics.Process( ))
    {
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.RedirectStandardOutput = true;
        p.StartInfo.FileName = PathToBatchFile;
        p.StartInfo.Arguments = args;
        p.Start( );
        string o = p.StandardOutput.ReadToEnd( );
        p.WaitForExit( );
    }
