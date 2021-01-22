    // in your Web service class
    [WebMethod]
    public UploadResponse Upload( UploadRequest request ) {
        ...
    }
    ...
    
    [Serializable]
    public class UploadResponse {
      public bool IsSuccessful {
        get { ... }
        set { ... }
      }
    }
    
    [Serializable]
    public class UploadRequest {
      public Allocation ReferenceAllocation {
        get { ... }
        set { ... }
      }
      // define other request properties
      // ...
    }
