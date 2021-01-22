    private RegisterHotKeyClass _RegisKey = new RegisterHotKeyClass();
    
    void _Regis_HotKey()
    {
      MessageBox.Show("ok");
    } 
    
    private void Form1_Load(object sender, EventArgs e)
    {
      _RegisKey.Keys = Keys.PrintScreen;
      _RegisKey.ModKey = 0;
      _RegisKey.WindowHandle = this.Handle;
      _RegisKey.HotKey += new RegisterHotKeyClass.HotKeyPass(_Regis_HotKey);
      _RegisKey.StarHotKey();
    }
