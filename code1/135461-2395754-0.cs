    protected override void OnPreInit(EventArgs e)
	{
	 base.OnPreInit(e);
	 SPWeb myWeb = SPControl.GetContextSite(Context).OpenWeb();
	 string strUrl = myWeb.ServerRelativeUrl + "/_catalogs/masterpage/my.master";
	 this.MasterPageFile = strUrl;
	}
