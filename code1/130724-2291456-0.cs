    class myDict : Dictionary<string, Element> {
         public myDict() {}
         public myDict(IEnumerable<KeyValuePair<string, Element>> pairs)
         {
              foreach(var pair in pairs)
                   this.Add(pair.Key, pair.Value); // Add in all elements
         }
    }
