    public Control[] Find(string key, bool searchAllChildren)
    {
       if (string.IsNullOrEmpty(key))
       {
           throw new ArgumentNullException("key", SR.GetString("FindKeyMayNotBeEmptyOrNull"));
       }
       // Will always return an ArrayList with zero or more elements
       ArrayList list = this.FindInternal(key, searchAllChildren, this, new ArrayList());
       // Will always return an Array of zero or more elements
       Control[] array = new Control[list.Count];
       list.CopyTo(array, 0);
       return array;
   }
