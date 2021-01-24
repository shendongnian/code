	public Dictionary<Guid, string> DropdownLists
	{
		get { return ViewState["MyDropdowns"] != null
				? (Dictionary<Guid, string>)ViewState["MyDropdowns"] : new Dictionary<Guid, string>(); }
		set { ViewState["MyDropdowns"] = value; }
	}
	public Dictionary<Guid, string> DropdownNames
	{
		get { return ViewState["DropdownNames"] != null
		? (Dictionary<Guid, string>)ViewState["DropdownNames"] : new Dictionary<Guid, string>(); }
		set { ViewState["DropdownNames"] = value; }
	}
