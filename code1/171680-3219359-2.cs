    HashSet<Item.Key> seenIt = new HashSet<Item.Key>();
    HashSet<Item.Key> returnedIt = new HashSet<Item.Key>();
    
    IEnumerable<Item> result =
      items.Where(item => 
    {
      key = Item.Key;
      if (!seenIt[key])
      {
        seenIt.Add(key);
      }
      else if (!returnedIt[key])
      {
        returnedIt.Add(key)
        return true;
      }
      return false;
    });
