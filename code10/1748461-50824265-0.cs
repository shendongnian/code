    [OnSerializing()]
    internal void OnSerializingMethod(StreamingContext context)
    {
       if (this.version.Revision == -1)
       {
          //handle it properly 
    
          or
    
          this.version.Revision = default(int)// will not be serialized as you are using "EmitDefaultValue=false"
       }
    }
