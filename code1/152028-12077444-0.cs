    string s = "(params (abc 1.3)(sdc 2.0))"
      .Replace(" ", ":")
      .Replace("(", "{")
      .Replace(")","}"); 
    
    return new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize(s);
