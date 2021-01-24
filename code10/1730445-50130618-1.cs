    public class EntitiesMigrate : IEntitiesMigrate
    {
        public IDbSet<MyEntity> MyEntities {get; set;}
        public IDbSet<MergeUserLine> MergeUserLines { get; set; }
    }
    
    public interface IEntitiesMigrate
    {
        IDbSet<MyEntity> MyEntities {get; set;}
        IDbSet<MergeUserLine> MergeUserLines { get; set; }
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
    db.Setup(d=> d.MyEntities).Returns(someData);
    db.Setup(d=> d.MergeUserLines).Returns(someOtherData);
