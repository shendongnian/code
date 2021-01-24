    using System.Data.Entity;
    public partial class EFEntities : DbContext // add this base class
    {
        public override int SaveChanges()
        {
            // manual override goes here
            return base.SaveChanges();
        }
    }
