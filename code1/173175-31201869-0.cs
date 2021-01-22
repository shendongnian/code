	public unsafe bool OdbcConnectionTest(string sConnectionString
		, out int actualTimeMs)
	{
		DateTime dtme = DateTime.Now;
		OdbcConnectionStringBuilder con;
		Microsoft.SqlServer.Management.Smo.Server svr;
		Microsoft.SqlServer.Management.Common.ServerVersion sVer;
		Microsoft.SqlServer.Management.Smo.Database db;
		try
		{
			con = new System.Data.Odbc.OdbcConnectionStringBuilder(sConnectionString);
			object sServer;
			if (con.TryGetValue("server", out sServer))
			{
				svr = new Microsoft.SqlServer.Management.Smo.Server((string)sServer);
				if (svr != null)
				{
					sVer = svr.PingSqlServerVersion((string)sServer);
					if (sVer != null)
					{
						object sDb;
						if (con.TryGetValue("database", out sDb))
						{
							if (!String.IsNullOrWhiteSpace((string)sDb))
							{
								db = svr.Databases[(string)sDb];
								if (db != null && db.IsAccessible)
								{
									TimeSpan ts = DateTime.Now - dtme;
									actualTimeMs = (int)ts.TotalMilliseconds;
									return true;
								}
							}
						}
					}
				}
			}
		}
		catch 
		{
			actualTimeMs = -1;
			return false;
		}
		actualTimeMs = -1;
		return false;
	}
