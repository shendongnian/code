    private void GetInfo_Click(object sender, System.EventArgs e)
    {
      WS.WebService services = new WS.WebService();
    
      SubLibrary info = services.GetInfo();  // This of course doesn't convert.
    
      MessageBox.Show(info.GetValue());
    }
