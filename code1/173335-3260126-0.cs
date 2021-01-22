    Dictionary<string, List<string>> dictionary = this.CollectTableListings();
    Dictionary<string, List<string>> otherDictionary = getOtherTable();
    var keys = from key in dictionary.Keys
               where !otherDictionary.Keys.Contains(key)
               select key;
