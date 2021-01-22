      Dictionary<string, string> myDictionary = new Dictionary<string, string>();
      myDictionary.Add("key", "value");
      myDictionary.Add("key2", "value");
      var myJson = JsonConvert.SerializeObject(myDictionary);
      var myXml = JsonConvert.DeserializeXNode(myJson.ToString(),"root");
      Console.WriteLine(myXml.ToString());
      Console.Read();
