    Item GetItem(string id)
    {
         if(string.IsNullOrEmpty(id) == true){ return null; }
         Item item = null;
         this.dict.TryGetValue(id, out item);
         return item;
    }
