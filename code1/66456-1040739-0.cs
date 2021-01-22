       System.Diagnostics.ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo();
        start.UseShellExecute = false;
        start.RedirectStandardInput = true;
        start.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
    
        start.RedirectStandardOutput = true;
        start.FileName = "at";
    System.Diagnostics.Process myP = System.Diagnostics.Process.Start(start);
    String strOutput = myP.StandardOutput.ReadToEnd();
    if (strOutput.Contains("There are no entries in the list."))
    {
        litMsg.Text = "There are no jobs";
    }
    else
    {
        strOutput = strOutput.Replace("\r", "");
        foreach (String line in strOutput.Split("\n".ToCharArray()))
        {
            //(0,7)  (7,5)(12, 24)                (36, 14)      (50, )
            //Status ID   Day                     Time          Command Line
            //-------------------------------------------------------------------------------
            //        1   Tomorrow                3:00 AM       dir *
            if (line.Length > 50)
            {
                String Status = line.Substring(0, 7);
                String ID = line.Substring(7, 5);
                String Day = line.Substring(12, 24);
                String Time = line.Substring(35, 14);
                String Command = line.Substring(49);
            }
        }
    }
