    SPWeb web = SPContext.Current.Web;
    SPSiteDataQuery query=new SPQuery();
    
    //write your own query
    // ...
    
    //execute the query 
    DataTable tbl = web.GetSiteData(query);
