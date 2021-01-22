    private static CacheItemRemovedCallback OnCacheRemove = null;
    
    private void AddTask(string name, int seconds)
    {
        OnCacheRemove = new CacheItemRemovedCallback(CacheItemRemoved);
        HttpRuntime.Cache.Insert(name, seconds, null, DateTime.Now.AddSeconds(seconds), Cache.NoSlidingExpiration, CacheItemPriority.NotRemovable, OnCacheRemove);
    }
    
    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        // delete old spreadsheets every hour
        AddTask("DeleteDayOldSpreadsheets", 3600);
        
    }
    public void CacheItemRemoved(string k, object v, CacheItemRemovedReason r)
    {
        // do stuff here
        switch (k)
        {
            case "DeleteDayOldSpreadsheets":
                // TODO: add your magic DELETE OLD SPREADSHEET code here
                break;    
                
            default:
                break;
        }
        
        // re-add our task so it recurs
        AddTask(k, Convert.ToInt32(v));
    }
