    [Serializable]
    class Parent : IDeserializationCallback 
    {
      public List<child> children;
    
      void IDeserializationCallback.OnDeserialization(Object sender) 
      {
        if (null != children)
        {
          children.ForEach(c => c.parent = this);
        }
      }
    }
