    public class myIdentity : IIdentity
    {
       public string IIdentity.Name {get; set;}
       public string UserId 
       { 
          get 
          { 
            return IIdentity.Name;
          }
          set 
          { 
            IIdentity.Name = value;
          }
    }
