     public partial class RDSS_WBEntities : DbContext
        {
            public RDSS_WBEntities() : base("name=RDSS_WBEntities")
            {
                this.Database.CommandTimeout = int.MaxValue;
            }
        }
