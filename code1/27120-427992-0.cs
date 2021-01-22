    public void Dump(object obj)
    {
      if(obj is IList)
      {
         DumpList((IList)list);
      }
      else if(obj is IDictionary)
      {
         DumpDictionary(dict)  
      }
      else
      {
        Console.WriteLine(obj); 
      }
    }
    public void DumpList(IList list)
    {
        foreach(object item in list)
        {
          Dump(item);
        }
    }
    
    public void DumpDictionary(IDictionary dict)
    {
        foreach (DictionaryEntry entry in dict)
        {
          Dump(entry.Key);
          Console.Write("=");
          Dump(entry.Value);
        }
    }
