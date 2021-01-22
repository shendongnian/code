    public interface IEntityReadOnly
    {
        int Prop { get; }
    }
    public interface IEntity : IEntityReadOnly
    {
        int Prop { set; }
    }
    public class Entity : IEntity
    {
        public int Prop { get; set; }
    }
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var entity = new Entity();
            (entity as IEntity).Prop = 2;
            Assert.AreEqual(2, (entity as IEntityReadOnly).Prop);
        }
    }
