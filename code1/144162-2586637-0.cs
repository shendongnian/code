    private bool ValidateSettings()
    {
      if ((chkDownload.Checked && String.IsNullOrEmpty(txtAppName.Text))||
        (chkpplaORfmp.Checked && String.IsNullOrEmpty(txtfmpORppla.Text)))
      {
        if (chkDownload.Checked)
        divAppDownloadError.Visible=true;
        else divXPAAPPDownloadError.Visible = true;
       
        return false;
      }
        return true;
      }
