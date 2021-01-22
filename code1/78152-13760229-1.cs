    using (SPSite site = new SPSite("http://mysite"))
    {    
        SPServiceContext serviceContext = SPServiceContext.GetContext(site);
        SearchServiceApplicationProxy searchAppProxy = ((SearchServiceApplicationProxy)SearchServiceApplicationProxy.GetProxy(serviceContext));
    
        for (int i = 0; i < 6; i++)         // You need at least 6 here to make a query popular
        {
            string queryStr = "testme";
            string queryId = Guid.NewGuid().ToString();
            string sessionId = Guid.NewGuid().ToString();
            string clickedUrl = "http://mysite/Shared%20Documents/testme.txt";
                       
            QueryInfo info = new QueryInfo();
            info.QueryGuid = queryId;
            info.SiteGuid = site.ID.ToString();
            info.SessionId = sessionId;
            info.UserName = System.Threading.Thread.CurrentPrincipal.Identity.Name;
            info.QueryString = queryStr;
            info.StartItem = 1;
            info.ClickTime = DateTime.Now;
            info.ClickedUrl = clickedUrl;
            info.ResultsUrl = "http://mysite/fast/Pages/results.aspx?k=testme";
            info.ClientType = QueryLogClientType.ObjectModel;
            info.SearchTime = DateTime.Now;      
    
            // Send a Click QueryInfo
            info.LogType = QueryLogType.Click;
            searchAppProxy.RecordClick(info);    
    
            // Send a Query QueryInfo
            info.LogType = QueryLogType.Query;
            searchAppProxy.RecordClick(info);   
         }
    } 
