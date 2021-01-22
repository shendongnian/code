    public Type FindClass(string name)
    {
       Assembly ass = null;
       ass = Assembly.Load("System.My.Assembly"); // Load from the GAC
       ass = Assembly.LoadFile(@"c:\System.My.Assembly.dll"); // Load from file
       ass = Assembly.LoadFrom("System.My.Assembly"); // Load from GAC or File
       foreach(Type t in ass.GetTypes())
       {
          if (t.Name == name)
             return t;
       }
       return null;
    }
