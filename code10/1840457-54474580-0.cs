    Process p = Process.Start(process); 
    frm_Save fsave = new frm_Save(); 
    fsave.TopMost = true; 
    fsave.Show();
    using (p)
    {
        while (!p.WaitForExit(1000))
        {
            fsave.Refresh();
        }
    }
    fsave.Close();
