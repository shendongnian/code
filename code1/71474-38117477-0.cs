    		this._server = config.GetAttribute("server");
		**this._workspace = config.GetAttribute("workspace");**
		this._user = config.GetAttribute("user");
		this._password = config.GetAttribute("psw");
		TeamFoundationServer tfs = new TeamFoundationServer(this._server, new System.Net.NetworkCredential(this._user, this._password));
		tfs.Authenticate();
		VersionControlServer versionControl = (VersionControlServer)tfs.GetService(typeof(VersionControlServer));
		Workspace ws = versionControl.GetWorkspace(this._workspace, this._user);
