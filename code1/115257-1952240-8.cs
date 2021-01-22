    var dlg = new ProgressDlg<string>(obj =>
                                      {
                                         //DoWork()
                                         Thread.Sleep(10000);
                                         MessageBox.Show("Background task completed "obj);
                                       });
    dlg.RunWorker("SampleValue");
    if (dlg.Error != null)
    {
      MessageBox.Show(dlg.Error.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    dlg.Dispose();
