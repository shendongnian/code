    protected override void OnClosing(CancelEventArgs e)
    {
        base.OnClosing(e);
    
        Form dlg=null;
        ThreadPool.QueueUserWorkItem(state => {
            dlg = new ShuttingDownUI();
            dlg.ShowDialog();
        });
    
        // do hard work with saving and stuff
        if (dlg != null)
        {
            dlg.BeginInvoke((Action) dlg.Close);
        }
    }
