    // clear any session vars that haven't been read in x requests
    List<string> keysToRemove = new List<string>();
    for (int i = 0; HttpContext.Current.Session != null && i < HttpContext.Current.Session.Count; i++)
    {
        var sessionObject = HttpContext.Current.Session[i] as SessionHelper.SessionObject2;
        string countKey = "ReadsFor_" + HttpContext.Current.Session.Keys[i];
        if (sessionObject != null/* && sessionObject.IsFlashSession*/)
        {
            if (HttpContext.Current.Session[countKey] != null)
            {
                if ((int)HttpContext.Current.Session[countKey] == sessionObject.Reads)
                {
                    keysToRemove.Add(HttpContext.Current.Session.Keys[i]);
                    continue;
                }
            }
            HttpContext.Current.Session[countKey] = sessionObject.Reads;
        }
        else if (HttpContext.Current.Session[countKey] != null)
        {
            HttpContext.Current.Session.Remove(countKey);
        }
    }
    foreach (var sessionKey in keysToRemove)
    {
        string countKey = "ReadsFor_" + sessionKey;
        HttpContext.Current.Session.Remove(sessionKey);
        HttpContext.Current.Session.Remove(countKey);
    }
