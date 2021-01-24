    private void frmTick_Load(object sender, EventArgs e)
    {
        string sPath = @"C:\develop\operate.xml";
    
        if (!File.Exists(sPath))
        {
            BeginInvoke(new MethodInvoker(delegate
            {
               Hide();
            }));
            var frmCheckTick = new frmCheckTick();
            frmCheckTick.Show();
    
        }
    }
