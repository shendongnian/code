    string input = null;
    using (StreamReader reader = new StreamReader (listenerRequest.InputStream)) {
        input = reader.ReadToEnd ();
    }
    NameValueCollection coll = HttpUtility.ParseQueryString (input);
