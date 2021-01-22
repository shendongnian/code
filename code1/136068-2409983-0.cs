    object Twitter = Cache["MyTwitter"];
    if(Twitter==null)
    {
        // cache empty
        try
        { 
            var latestItems = (load items)
            Cache.Insert("MyTwitter", latestitems, null, DateTime.Now.AddSeconds(600),
                Cache.NoSlidingExpiration);
            Twitter = latestitems;
        }
        catch(Exception ex)
        {
            Cache.Insert("MyTwitter", ex.ToString(), null, DateTime.Now.AddSeconds(60),
                Cache.NoSlidingExpiration);
            Twitter = ex.ToString();
        }
    }
    if(Twitter is string)
    {
        phError.Visible = true;
    }
    else
    {
        rptTwitter.DataSource = Twitter;
        // rest of data binding code here
    }
