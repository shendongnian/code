    public partial class LightCRMEntities : DbContext
    {
        public LightCRMEntities()
            : base("name=LightCRMEntities")
        {
            Configuration.LazyLoadingEnabled = false;
        }
    // other code
    }
