    protected void btnClearCache_Click(object sender, EventArgs e)
    {
        var enumerator = HttpRuntime.Cache.GetEnumerator();
 
        while (enumerator.MoveNext())
            HttpRuntime.Cache.Insert(enumerator.Key.ToString(), enumerator.Value, 
                null, DateTime.Now , Cache.NoSlidingExpiration);
    }
