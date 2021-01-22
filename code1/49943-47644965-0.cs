    Dictionary<string, string> parameters = new Dictionary<string, string>();
    
    for (int i = 0; i < context.Request.QueryString.Count; i++)
    {
        parameters.Add(context.Request.QueryString.GetKey(i), context.Request.QueryString[i]);
    }
