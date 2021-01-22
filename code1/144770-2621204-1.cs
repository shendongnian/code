	AzAuthorizationStoreClass AzManStore = new AzAuthorizationStoreClass();
	string connString = ConfigurationManager.ConnectionStrings["AuthorizationServices"].ConnectionString;
	string path = Server.MapPath(connString.Substring("msxml://".Length));
	AzManStore.Initialize(0, "msxml://" + path, null);
	IAzApplication azApp = AzManStore.OpenApplication("AppName", null);
	PlaceHolder p = new PlaceHolder();
	StringBuilder sb = new StringBuilder();
	sb.Append("<ul>");
	foreach (IAzRole role in azApp.Roles)
	{
		sb.Append("<li>");
		sb.Append(role.Name);
		sb.Append("<ul>");
		foreach (object member in (object[])role.MembersName)
		{
			sb.Append("<li>");
			sb.Append(member);
			sb.Append("</li>");
		}
		sb.Append("</ul>");
		sb.Append("</li>");
	}
	sb.Append("</ul>");
	p.Controls.Add(new LiteralControl(sb.ToString()));
	form1.Controls.Add(p);
