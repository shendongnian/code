    private Node GetNode(object key) 
    {
      var index = GetHash(key);
      var node = _table[index];
      while (true)
      {
        if (node == null)
          throw ...
        if (Equals(node.Key, key))
          return node;
        node = node.Next;
      }
    }
    private object GetValue(object key) => GetNode(key).Value;
    private void SetValue(object key, object value)
    {
      if (value == null)
        RemoveValue(key);
      else 
        GetNode(key).Value = value;
    }
