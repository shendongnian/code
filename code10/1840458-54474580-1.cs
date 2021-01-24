    frm_Save fsave = new frm_Save(); 
    fsave.TopMost = true; 
    fsave.Show();
    Process p = Process.Start(process); 
    using (p)
    {
        while (!p.WaitForExit(1000))
        {
            fsave.Refresh();
        }
    }
    fsave.Close();
