    [Serializable]
    public class StorageObject {
      public string Name { get; set; }
      public string Birthday { get; set; }
      [Nonserializable]
      public Dictionary<string,List<string>> OtherInfo { get; set; }  
    }
    [WebMethod]
    public List<StorageObject> GetStorageObjects() {
        // returns list of storage objects from persistent storage or cache
    }
    [WebMethod]
    public List<string> GetStorageObjectAttributes( string name )
    {
        // find storage object, sObj
        return sObj.Keys.ToList();
    }
    [WebMethod]
    public List<string> GetStorageObjectAtributeValues( sting name, string attribute )
    {
        // find storage object, sObj
        return sObj[attribute];
    }
 
