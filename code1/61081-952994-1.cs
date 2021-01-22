    public class KillerApp
    {
        private IRepository<BusinessObject> repository;
        private ISomeOtherClass someOtherClass;
        public KillerApp(IRepository<BusinessObject> repository, ISomeOtherClass someOtherClass)
        {
            this.repository = repository;
            this.someOtherClass = someOtherClass;
        }
        public void DoThatThing()
        {
            BusinessObject[] entities = repository.FindAll();
            someOtherClass.HandleNewBizObjs(entities);
        }
    }
    [TestClass]
    public class When_Doing_That_Thing
    {
        private const String DatabasePath = /* test path */;
        private IRepository<BusinessObject> repository;
        private ISomeOtherClass someOtherClass = new SomeOtherClass();
        private KillerApp app;
        [TestInitialize]
        public void TestInitialize()
        {
            repository = new BusinessObjectRepository(DatabasePath);
            app = new KillerApp(repository, someOtherClass);
        }
        [TestMethod]
        public void Should_convert_all_gizmo_records_to_busn_objects()
        {
            app.DoThatThing();
            Assert.AreEqual(someOtherClass.Results, /* however you're confirming */);
        }
    }
