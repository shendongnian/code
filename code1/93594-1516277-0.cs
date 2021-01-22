    public Dictionary<string, object> qsValues = new Dictionary<string, object>();
    
    foreach (string key in Request.QueryString.Keys) {
        if (Request.QueryString[key].Count > 1) {
            qsValues[key] = Request.QueryString[key][0];
        }
        else {
            qsValues[key] = Request.QueryString[key];
        }
    }
