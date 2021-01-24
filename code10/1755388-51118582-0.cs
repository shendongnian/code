    private static void SetHeaderRestriction(string name, bool restricted) {
    	var hInfoPi = typeof(WebHeaderCollection)
    		.GetField("HInfo", BindingFlags.NonPublic | BindingFlags.Static);
    	var headerInfoTableType = hInfoPi.GetValue(null).GetType();
    	var headerInfoHashPi = headerInfoTableType
    		.GetField("HeaderHashTable", BindingFlags.NonPublic | BindingFlags.Static);
    	// headerInfohash is the internal static cache controlling header restrictions
    	var headerInfoHash = (Hashtable)headerInfoHashPi.GetValue(null);
    	var connectionHeaderInfo = headerInfoHash["Connection"];
        // IsRequestRestricted is 'readonly', but reflection can trump.
        // An alternative would be to [temporarily] replace the entry entirely.
    	var restrictedPi = connectionHeaderInfo.GetType()
    		.GetField("IsRequestRestricted", BindingFlags.NonPublic | BindingFlags.Instance);
    	restrictedPi.SetValue(connectionHeaderInfo, false);
    }
    
    void Main()
    {
    	SetHeaderRestriction("Connection", false);
    	var wr = (HttpWebRequest)WebRequest.Create("http://www.google.com");
    	wr.Headers["Connection"] = "keep-alive";
    	wr.Connection.Dump(); // "keep-alive"
    	SetHeaderRestriction("Connection", true);
    	((HttpWebResponse)wr.GetResponse()).StatusCode.Dump(); // OK
    }
