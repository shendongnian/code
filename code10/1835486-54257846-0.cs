    private Thread passwordClearThread = null;
    private void getPassword(int lifeInSeconds)
    {
      int maxLifeBarValue = lifeInSeconds * 10;
      if (passwordClearThread != null && passwordClearThread.IsAlive)
      {
        passwordClearThread.Abort();
        passwordClearThread.Join();
      }
      passwordClearThread = new Thread
      (() =>
      {
        //Initialize the progress bar
        Invoke((MethodInvoker)delegate
        {
          lifeBar.Maximum = maxLifeBarValue;
          lifeBar.Value = maxLifeBarValue;
          lifeBar.Visible = true;
          Clipboard.SetText(pd.getAccountPassword(lstAccounts.Text));
        });
        //Loop to update the progress bar
        for (int x = maxLifeBarValue; x >= 0; x--)
        {
          Thread.Sleep(100);
          Invoke((MethodInvoker)delegate
          {
            lifeBar.Value = x;
          });
        }
        //Clear the system clipboard
        Clipboard.Clear();
        //Hide the progress bar when we're done
        Invoke((MethodInvoker)delegate
        {
          lifeBar.Visible = false;
        });
      });
      passwordClearThread.SetApartmentState(ApartmentState.STA);
      passwordClearThread.Start();
    }
