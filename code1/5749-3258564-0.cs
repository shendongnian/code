            List<Object> listOfObjects = null;
    //assuming a List of Objects... it doesn't matter whatever type of data you use
            if (Context.Cache["MyDataCacheKey"] == null)
            {
                // data not cached, load it from database
                listOfObjects = GetDataFromDB();
    //add your data to the context cache with a sliding expiration of 10 minutes.
                Context.Cache.Add("MyDataCacheKey", listOfObjects, null,
                    System.Web.Caching.Cache.NoAbsoluteExpiration,
                    TimeSpan.FromMinutes(10.0),
                    System.Web.Caching.CacheItemPriority.Normal, null);
            }
            else
                listOfObjects = (List<Object>)Context.Cache["MyDataCacheKey"];
            DropDownList1.DataSource = listOfObjects;
            DropDownList1.DataBind();
