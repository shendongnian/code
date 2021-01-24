    protected void Unnamed_PreRender(object sender, EventArgs e)
	{
		string str = ((HyperLink)sender).NavigateUrl;
		if (str.Contains("XXX")
			((HyperLink)sender).ForeColor = System.Drawing.Color.Red;
	}
