    private bool ValidateSettings()
    {
		if (chkDownload.Checked && String.IsNullOrEmpty(txtAppName.Text) && chkpplaORfmp.Checked && String.IsNullOrEmpty(txtfmpORppla.Text))
		{
			divAppDownloadError.Visible = true;
			divXPAAPPDownloadError.Visible = true;
			return false;
		}
		if ((chkDownload.Checked && String.IsNullOrEmpty(txtAppName.Text)) || (chkpplaORfmp.Checked && String.IsNullOrEmpty(txtfmpORppla.Text)))
		{
			if (chkDownload.Checked && String.IsNullOrEmpty(txtAppName.Text))
			{
				divAppDownloadError.Visible = true;
				divXPAAPPDownloadError.Visible = false;
			}
			else
			{
				divXPAAPPDownloadError.Visible = true;
				divAppDownloadError.Visible = false;
			}
			return false;
		} return true; 
    }
