    public int UserID
    {
       get
       {
          if (this.User != null)
             return this.User.UserID;
       }
       set 
       {
          this.UserReference.EntityKey = new System.Data.EntityKey("entities.User", "ID", value);
       }
    }
