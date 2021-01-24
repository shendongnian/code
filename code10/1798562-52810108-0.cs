    [ProtoAfterDeserialization]
    protected void AfterDeserialization()
    {
       var engineTypes = RetrieveEngineTypes();
       if (EngineProfiles != null && EngineProfiles.Length == engineTypes.Count) return;
       .......
    }
