    public class KillerApp
    {
        private String databasePath;
        private ISomeOtherClass someOtherClass;
        public KillerApp(String databasePath, ISomeOtherClass someOtherClass)
        {
            this.databasePath = databasePath;
            this.someOtherClass = someOtherClass;
        }
        public void DoThatThing()
        {
            var connection = OpenSqliteConnection(databasePath);
            var allGizmoRecords = connection.Query(...);
            var businessObjects = TransformIntoBizObjs(allGizmoRecords);
            someOtherClass.HandleNewBizObjs(businessObjects);
        }
    }
    [TestClass]
    public class When_Doing_That_Thing
    {
        private const String DatabasePath = /* test path */;
        private ISomeOtherClass someOtherClass = new SomeOtherClass();
        private KillerApp app;
        [TestInitialize]
        public void TestInitialize()
        {
            app = new KillerApp(DatabasePath, someOtherClass);
        }
        [TestMethod]
        public void Should_convert_all_gizmo_records_to_busn_objects()
        {
            app.DoThatThing();
            Assert.AreEqual(someOtherClass.Results, /* however you're confirming */);
        }
    }
