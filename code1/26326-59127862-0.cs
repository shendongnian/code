    private void ie_DocumentCompleted(object _sender, WebBrowserDocumentCompletedEventArgs e)
    {
        System.Windows.Forms.WebBrowser ie = (System.Windows.Forms.WebBrowser)_sender;
    
        string strKey = "Software\\Microsoft\\Internet Explorer\\PageSetup";
        bool bolWritable = true;
        RegistryKey ok = Registry.CurrentUser.OpenSubKey(strKey, bolWritable);
        
        ok.SetValue("margin_left", 0.75, RegistryValueKind.String);
    
        string reg_validation = (string) ok.GetValue("margin_left");
    
        ie.ShowPageSetupDialog();
    
        if (reg_validation.Equals((string)ok.GetValue("margin_left")))
        {
            MessageBox.Show("Cancel");
        }
        else
        {
            MessageBox.Show("OK");
            ie.Print();
        }
        ok.Close()
    }
