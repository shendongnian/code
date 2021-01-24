	public IEnumerable<SelectListItem> ServerItems
	{
		get 
		{
			return Servers.Select
            (
                server => 
				new 
				{
				    Server = server,
					UserCount = Users.Count( u => u.ServerId = server.Id )
			    }
			)
			.Select
			(
			    item =>
				new SelectListItem
				{
				    Value = item.Server.Id.ToString(),
					Text = string.Format
					(
                        @"{0}{1} ({2} users on)" ,
                        item.Server.InstanceCode,
                        item.Server.ServerName, 
						item.UserCount
                    )
			    }
			);
        }
    }
