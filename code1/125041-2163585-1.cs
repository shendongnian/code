    public CustomDataContext : InternalCustomDataContext /* created in designer */
    {
     protected string GetCustomConnectionString() {
       return ConfigurationManager.ConnectionStrings["CustomConnectionString"].ConnectionString;
     }
     public CustomDataContext() : base(GetCustomConnectionString())
     {}
    }
