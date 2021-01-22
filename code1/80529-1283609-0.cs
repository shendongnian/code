     using System.Diagnostics;
        Process p = new Process();
        ProcessStartInfo pi = new ProcessStartInfo();
        pi.UseShellExecute = true;
        pi.FileName = @"MY_FILE_WITH_FULL_PATH.jpg";
        p.StartInfo = pi;
    
        try
        {
            p.Start();
        }
        catch (Exception Ex)
        {
            //MessageBox.Show(Ex.Message);
        }
