    public static long GetIdForUrl(string inputUrl) 
    {
        using (ShortUrlEntities db = new ShortUrlEntities())
        {
            var checkUrl = (from t in db.ShortURLSet 
                            where t.url == inputUrl select t.id);
            if (checkUrl.Count() == 1) 
            {
                return checkUrl.First();
            }
            else
            {
                return 0;
            }
        }
    }
