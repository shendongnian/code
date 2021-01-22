    public void Print(FileInfo file)
    {
        ProcessStartInfo psi = new ProcessStartInfo();
        psi.FileName = "print";
        psi.Arguments = string.Format("/D:\"{0}\" \"{1}\"", Printer, file.FullName);
        psi.CreateNoWindow = true;
        psi.UseShellExecute = false;
    
        Process p = new Process();
        p.StartInfo = psi;
        p.Start();
    
        while (!p.HasExited) ;
    }
