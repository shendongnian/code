    [Serializable]
    class SerializableEntity
    {
      [OnDeserialized]
      private void OnDeserialized()
      {
        id = RetrieveId();
      }
    
      private int RetrievId() {}
      [NonSerialized]
      private int id;
    }
