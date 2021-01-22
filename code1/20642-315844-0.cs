    Dictionary<String,String> regKeys = new Dictionary<String,String>()
    {
        { "Key1", String.Empty},
        { "Key2", String.Empty},
        { "Key3", String.Empty}
    };
    
    for (int i = 0; i < regKeys.Length; i++)
    {
       try
       {
           regKeys[i].Value = ReadFromRegistry(regKeys[i].Key);
       }
       catch (Exception ex)
       {
          Console.WriteLine("Unable to read Key: " + regKeys[i].Key 
             + " Exception: " + ex.Message);
       } 
    }
