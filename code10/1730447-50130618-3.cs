    public class EntitiesMigrate : IEntitiesMigrate
    {
        public DbSet<MyEntity> MyEntities {get; set;}
        // or standardise on public IDbSet<MyEntity> MyEntities {get; set;}
        public DbSet<MergeUserLine> MergeUserLines { get; set; }
    }
    
    public interface IEntitiesMigrate
    {
        DbSet<MyEntity> MyEntities {get; set;}
        // or standardise on IDbSet<MyEntity> MyEntities {get; set;}
        DbSet<MergeUserLine> MergeUserLines { get; set; }
        // Don't forget SaveChanges() and whatever else you need
    }
    
    // then remove this in your classes
    using (var db = new EntitiesMigrate().AutoLocal())
    
    // instead in your constructor
    public class SomeClass
    {
        public SomeClass(IEntitiesMigrate db)
        {
            _db = db;
        }
    }
    // then testing...
    var db = new Mock<IEntitiesMigrate>();
    var someOtherData = new Mock<DbSet<MergeUserLine>>(); 
    // whereas IDbSet is easier to mock, DbSet will give you all the properties and methods you need. 
    // see https://msdn.microsoft.com/en-us/library/dn314429(v=vs.113).aspx for setting up mock DbSets
    db.Setup(d=> d.MyEntities).Returns(someData.Object);
    db.Setup(d=> d.MergeUserLines).Returns(someOtherData.Object);
