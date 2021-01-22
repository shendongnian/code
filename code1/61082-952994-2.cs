    [ActiveRecord] /* You define your database schema on the object using attributes */
    public BusinessObject
    {
        [PrimaryKey]
        public Int32 Id { get; set; }
        [Property]
        public String Data { get; set; }
        /* more properties */
    }
    public class KillerApp
    {
        private ISomeOtherClass someOtherClass;
        public KillerApp(ISomeOtherClass someOtherClass)
        {
            this.someOtherClass = someOtherClass;
        }
        public void DoThatThing()
        {
            BusinessObject[] entities = BusinessObject.FindAll() /* built-in ActiveRecord call! */
            someOtherClass.HandleNewBizObjs(entities);
        }
    }
    [TestClass]
    public class When_Doing_That_Thing : ActiveRecordTest /* setup active record for testing */
    {
        private ISomeOtherClass someOtherClass = new SomeOtherClass();
        private KillerApp app;
        [TestInitialize]
        public void TestInitialize()
        {
            app = new KillerApp(someOtherClass);
        }
        [TestMethod]
        public void Should_convert_all_gizmo_records_to_busn_objects()
        {
            app.DoThatThing();
            Assert.AreEqual(someOtherClass.Results, /* however you're confirming */);
        }
    }
