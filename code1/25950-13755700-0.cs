    private void Ping_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
      int count = this.dg.Rows.Count;
      System.Threading.Tasks.Parallel.For(0, count, i => 
      {
        string ip = UIF<string>(() => this.GetIp(i));
        bool r = GoPingIt(ip);
        UIA(() => this.SetPing(i, r));
      });
      UIA(() => SetAllControlsEnabled(true));
    }
