    int min = 1;
    int max = 100;
    Random random;
    Hashtable hash = new Hashtable();
    for (int x = min; x <= max; x++)
    {
    	random = new Random(DateTime.Now.Millisecond + x);
    	hash.Add(random.Next(Int32.MinValue, Int32.MaxValue), x);
    }
    foreach (int key in hash.Keys)
    {
    	HttpContext.Current.Response.Write("<br/>" + hash[key] + "::" + key);
    }
    hash.Clear(); // cleanup
