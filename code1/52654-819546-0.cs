    progressBar = new ProgressBar();
    progressBar.Update(0.0,"Sending CRC table...");
    for (int i = 0; i < MyCRC.Length; i++)
    {
        MySP.Write(MyCRC[i].ToString("x8"));
        while(WySP.BytesToWrite != 0)
        {
            ;
        }
        progressBar.Percent = (((Double)(i+1))/MyCRC.Length);
    }
    progressBar.Update(100.0,"CRC table sent.");
