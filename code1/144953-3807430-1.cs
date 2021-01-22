    System.Diagnostics.Process proc = new System.Diagnostics.Process();
    proc.StartInfo.FileName = "trash filename here.exe";
    try
    {
        Proc.Start();
    }
    catch { }//proc should fail.
    try
    {
        if (proc.HasExited)
        {
            //....
        }
    }
    catch (System.InvalidOperationException e)
    {
        //cry and weep about it here.
    }
