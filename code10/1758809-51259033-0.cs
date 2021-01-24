    StatusBar statusBar1 = null;
    public void CreateMyStatusBar(string msg = "Ready")
    {
         if(statusBar1 == null) {
            statusBar1 = new StatusBar();
            Form1.gui.Controls.Add(statusBar1);
         }
         this.Invoke(new Action(() =>
         {
                statusBar1.Text = msg;
                statusBar1.Update();
         }));
         statusBar1.Invalidate();
         statusBar1.Refresh();
         statusBar1.Update();
    }
