    using (SPLimitedWebPartManager webPartManager =
    	SPContext.Current.Web.GetLimitedWebPartManager("default.aspx",
            PersonalizationScope.Shared))
    {
    	try
    	{
    		foreach (WebPart webPart in webPartManager.WebParts)
    		{
    			if (webPart.Title == "Web Part To Update")
    			{
    				ListViewWebPart listViewWebPart = (ListViewWebPart)webPart;
    				// TODO: Set property on web part
    				webPartManager.SaveChanges(listViewWebPart);
    				break;
    			}
    		}
    	}
    	finally
    	{
    		webPartManager.Web.Dispose();
    	}
    }
