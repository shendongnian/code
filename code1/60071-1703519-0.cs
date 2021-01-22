    <asp:SqlDataSource ID="x" EnableCaching="True" CacheKeyDependency="MyCacheDependency"/>
    protected void Page_Load(object sender, EventArgs e)
    { // Or somewhere else before the DataBind() takes place
      if (!IsPostBack)
      {
          //prime initial cache key value if never initialized
          if (Cache["MyCacheDependency"] == null)
          {
            Cache["MyCacheDependency"] = DateTime.Now;
          }
      }
    }
    // Evict cache items with an update in dependent cache:
    Cache["MyCacheDependency"] = DateTime.Now;
