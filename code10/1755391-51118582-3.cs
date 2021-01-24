    private static void SetHeaderRestriction(string name, bool restricted) {
    	var hInfoPi = typeof(WebHeaderCollection)
    		.GetField("HInfo", BindingFlags.NonPublic | BindingFlags.Static);
    	var headerInfoTableType = hInfoPi.GetValue(null).GetType();
    	var headerInfoHashPi = headerInfoTableType
    		.GetField("HeaderHashTable", BindingFlags.NonPublic | BindingFlags.Static);
    	// Internal cache singleton of header info / restriction data
    	var headerInfoHash = (Hashtable)headerInfoHashPi.GetValue(null);
    	var connectionHeaderInfo = headerInfoHash["Connection"];
        // IsRequestRestricted is 'readonly', but reflection can trump.
        // An alternative would be to [temporarily] replace the entry entirely.
    	var restrictedPi = connectionHeaderInfo.GetType()
    		.GetField("IsRequestRestricted", BindingFlags.NonPublic | BindingFlags.Instance);
    	restrictedPi.SetValue(connectionHeaderInfo, restricted);
    }
    
    void Main()
    {
    	var wr = (HttpWebRequest)WebRequest.Create("http://www.google.com");
    	SetHeaderRestriction("Connection", false);
    	wr.Headers["Connection"] = "keep-alive";
    	SetHeaderRestriction("Connection", true);
    	wr.Connection.Dump(); // "keep-alive"
    	((HttpWebResponse)wr.GetResponse()).StatusCode.Dump(); // OK
    }
