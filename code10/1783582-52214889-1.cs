    private void frmScreenSaver_Load(object sender, System.EventArgs e)
    {
      ...
      // fit the screen
      Bounds = Screen.AllScreens[ScreenNumber].Bounds;
      // hide the cursor... seems appropriate
      Cursor.Hide(); 
      // make it TopMost
      TopMost = true;
      ...
    }
