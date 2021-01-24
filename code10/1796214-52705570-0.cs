    var tokenResult = something.SelectToken(blahblahblah);
    List<JToken> listVersion;
    if (token is JToken)
    {
        listVersion = new List<JToken>();
        listVersion.Add(token);
    }
    else
    {
        listVersion = token.ToList();
    }
    // continue forward with listVersion instead of token.
        
