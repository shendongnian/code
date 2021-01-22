    Dictionary<string, object> values = new Dictionary<string, object>();
    
    foreach (string key in Request.Form.Keys) {
        if (key.Equals("SpecialFieldName")) {
            // for example, parse an int
            values.Add(key, int.parse(Request.Form[key]));
        } else {
            // no special formatting required
            values.Add(key, Request.Form[key]);
        }
    }
