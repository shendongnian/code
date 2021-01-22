    public string SomethingToReturn(string key, string value)
      {
           if (proccessValues.ContainsKey(name))
           {
               return proccessValues[name].Invoke(value);
           }
           return string.Empty;
       }
