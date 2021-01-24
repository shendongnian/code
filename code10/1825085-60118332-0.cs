    protected override void OnClosed(EventArgs e)
    {
        base.OnClosed(e);
         if (App.RequiresProcessKill)
         {
             var self = Process.GetCurrentProcess();
             self.Kill();
         }
    }
