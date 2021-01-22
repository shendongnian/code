    String querystring;
    ...
    // Parse the query string variables into a NameValueCollection.
    NameValueCollection qscoll = HttpUtility.ParseQueryString(querystring);
    // Iterate through the collection.
    StringBuilder sb = new StringBuilder();
    foreach (String s in qscoll.AllKeys)
    {
        sb.Append(s + " - " + qscoll[s] + "<br />");
    }
