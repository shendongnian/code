    [Serializable]
    class SerializableEntity: IDeserializationCallback 
    {
      void IDeserializationCallback.OnDeserialization(Object sender) 
      {
        id = RetrieveId();
      }
    
      private int RetrievId() {}
      [NonSerialized]
      private int id;
    }
