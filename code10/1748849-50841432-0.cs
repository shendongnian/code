    private bool asyncCloseHack = true;
    private async void frmSupportDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
             if (asyncCloseHack)
             {
                  e.Cancelled = true;
                  try
                  {
                      LockUserUI();
                      await AsyncTask();
                  }
                  finally
                  {
                      UnlockUserUI();
                  }
                  asyncCloseHack = false;
                  Close();
             }
        }
