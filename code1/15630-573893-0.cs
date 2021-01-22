    private void btnSTA_Click(object sender, System.EventArgs e)
    {
       DebuggingCOMLib.STAClass staobj =  new DebuggingCOMLib.STAClass();
       staobj.RaiseError(1,5);
       Label1.Text += "STA Call Completed sucessfully";
    }
