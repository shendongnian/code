    public NameValueCollection Metadata
      {
        get { 
              if (metadata == null)
                  metadata = new NameValueCollection();
    
              return metadata;
             }
      }
