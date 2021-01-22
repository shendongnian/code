    private bool ValidateSettings()
    {
        if (chkDownload.Checked && String.IsNullOrEmpty(txtAppName.Text))
        {
            divAppDownloadError.Visible=true;
            return false;
        }
        if (chkpplaORfmp.Checked && String.IsNullOrEmpty(txtfmpORppla.Text))
        {
            divXPAAPPDownloadError.Visible = true;
            return false;
        }
        
        // if you've gotten this far, neither of the
        // invalidating conditions above were held;
        // so you're good!
        return true;
    }
