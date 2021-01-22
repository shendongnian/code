    public void Open(string myPath)
    {
        Acrobat.AcroAVDocClass _acroDoc = new Acrobat.AcroAVDocClass();
        Acrobat.AcroApp _myAdobe = new Acrobat.AcroApp();
        Acrobat.AcroPDDoc _pdDoc = null;
        _acroDoc.Open(myPath, "test");
        _pdDoc = (Acrobat.AcroPDDoc) (_acroDoc.GetPDDoc());
        _acroDoc.SetViewMode(2);
        _myAdobe.Show();
        NotifyAdobeClosed += new EventHandler(Monitor_NotifyAdobeClosed);
        MonitorAdobe();
    }
    private void Monitor_NotifyAdobeClosed(object sender, EventArgs e)
    {
        NotifyAdobeClosed -= Monitor_NotifyAdobeClosed;
        //Do whatever it is you want to do when adobe is closed.
    }
    
    private void MonitorAdobe()
    {
        while(true)
        {
            var adcount = (from p in Process.GetProcesses()
                           where p.ProcessName.ToLower() == "acrobat"
                           select p).Count();
            if (adcount == 0)
            {
                OnNotifyAdobeClosed();
                break;
            }
        }
    }
    
    public event EventHandler NotifyAdobeClosed;
    public void OnNotifyAdobeClosed()
    {
        if (NotifyAdobeClosed != null)
            NotifyAdobeClosed(this, null);
    }
