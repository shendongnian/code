    public void Add(string key, object value)
    {
         if(value == null) {return;}
         var sval = value.ToString();
         if(sval != "")
         { Attributes.Add( key + "=\"" + sval + "\""}
    }
