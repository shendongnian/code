    var dlg = new ProgressDlg<string>(obj =>
                                      {
                                         //DoWork()
                                         Thread.Sleep(10000);
                                       });
    dlg.RunWorker(selectedView.Name);
    if (dlg.Error != null)
    {
      MessageBox.Show(dlg.Error.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    dlg.Dispose();
