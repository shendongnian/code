    public NameValueCollection Metadata
    {
        get
        {
            if(metadata == null)
                return (metadata = new NameValueCollection());
            else
                return metadata;
        }
    }
