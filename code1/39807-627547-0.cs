    public class IPod: IIdentifiable 
    {
          public long GetUniqueId() 
          {
               return this.serialNum + this.otherId;
          }
    }
    public class Cat: IIdentifiable 
    {
          public long GetUniqueId()
          { 
               return this.....
          }
    }
