    public void OpenBrowser()
    {
        System.Collections.Generic.List<PlatformInfo.BrowserInfo> bi = PlatformInfo.BrowserInfo.GetPreferableBrowser(); 
        string url = "\"" + "http://127.0.0.1:" + this.m_Port.ToString() + "/Index.htm\"";
        if (bi.Count > 0)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
            psi.FileName =bi[0].Path;
            psi.Arguments = url;
            
            System.Diagnostics.Process.Start(psi);
            return;
        }
        System.Diagnostics.Process.Start(url);
    } // End Sub OpenBrowser 
