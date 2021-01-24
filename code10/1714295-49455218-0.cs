    private void bgw_DoWork(object sender, DoWorkEventArgs e)
    {
      ...
      e.Result = RunModule.CheckConnection("GI SN", IP, port, this);
    }
    
    private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      var checkIP = (bool) e.Result;
      if (checkIP == false)
      {
        listView1.Items[0].BackColor = Color.Red;
        MessageOK("Failed to connect to the Laser Marker! Please check IP, Port and serial numbers match the Laser marker.", "warn");
        LabelShows(0);
      }
    }
