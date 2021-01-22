    private bool ValidateSettings()
    {
        if(chkDownload.Checked && String.IsNullOrEmpty(txtAppName.Text))
        {
            divAppDownloadError.Visible=true;
            return false; 
        }
        return true;
    }
