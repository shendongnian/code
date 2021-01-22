    private DataTable GetUser()
    {
    	//SPGroup User = null;
    
    	DataTable dt = new DataTable();
    	dt.Columns.Add("Survey Remeaning User");
    
    	DataTable dtuser = new DataTable();
    	dtuser.Columns.Add("Survey Completed User");
    
    
    	try
    	{
    		SPSecurity.RunWithElevatedPrivileges(delegate()
    		{
    			using (SPSite objSubSite = new SPSite(SPContext.Current.Site.Url))
    			{
    				SPUserCollection userCollection = SPContext.Current.Web.Groups["Survey Members"].Users;
    				foreach (SPUser user in userCollection)
    				{
    					StringBuilder sb = new StringBuilder();
    					sb.Append("<Where>");
    					sb.Append("<Eq>");
    					sb.Append("<FieldRef Name='Author' />");
    					sb.Append("<Value Type='User'>" + user + "</Value>");
    					sb.Append("</Eq>");
    					sb.Append("</Where>");
    
    					// query.ViewFields = "<FieldRef Name='Author'/>";
    					SPQuery query = new SPQuery();
    					query.Query = sb.ToString();
    
    					using (SPWeb objWeb = objSubSite.OpenWeb())
    					{
    						int i = objWeb.Lists["SurveyList"].GetItems(query).Count;
    						if (i == 0)
    						{
    							dt.Rows.Add(user);
    							GvUser.DataSource = dt;
    							GvUser.DataBind();
    						}
    						//if (i == 1)
    						else
    						{
    							//DataTable dtuser = new DataTable();
    							//dt.Columns.Add("SurveyCompleted");
    							dtuser.Rows.Add(user);
    							GvComUser.DataSource = dtuser;
    							GvComUser.DataBind();
    						}
    					}
    				}
    			}
    		});
    	}
    	catch (Exception)
    	{
    
    
    	}
    	return dt;
    }
