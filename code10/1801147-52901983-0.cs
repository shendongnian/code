    public static void AddResource(string resxFileName, string name, object value)
    {
       var fileName = $@".\Resources\{resxFileName}.resx";
    
       using (var writer = new ResXResourceWriter(fileName))
       {
          if (File.Exists(fileName))
          {
             using (var reader = new ResXResourceReader(fileName))
             {
                var node = reader.GetEnumerator();
                while (node.MoveNext())
                {
                   writer.AddResource(node.Key.ToString(), node.Value);
                }
             }
          }
    
          writer.AddResource(name, value);
       }
    }
