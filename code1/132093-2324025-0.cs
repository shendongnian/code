    [DataContract]
    public class ErrorBase
    {
      [DataMember]
      public virtual string Message 
      {
          get { return ""; } 
          set { }
      }
    }
