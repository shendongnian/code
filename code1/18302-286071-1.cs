    private UserObject CurrentUser
    {
         get
         {
              return this.Session["CurrentUser"] as UserObject;
         }
         set
         {
              this.Session["CurrentUser"] = value;
         }
    }
