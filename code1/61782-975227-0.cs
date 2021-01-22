    public static StringDictionary NamedValues = new StringDictionary();
    public static ClassName() // static construtor
    {
      StringCollection keys = Properties.Settings.Default.Keys;
      StringCollection vals = Properties.Settings.Default.Values;
      for(int i = 0; i < keys.Count(); i++)
      {
         NamedValues.Add(keys[i], vals[i]);
      }
    }
 
