    [TestClass]
    public class UnitySafeBehaviorExtensionTests : ITest
    {
        private IUnityContainer Container;
        private List<Exception> FirstChanceExceptions;
        [TestInitialize]
        public void TestInitialize()
        {
            Container = new UnityContainer();
            FirstChanceExceptions = new List<Exception>();
            AppDomain.CurrentDomain.FirstChanceException += FirstChanceExceptionRaised;
        }
        [TestCleanup]
        public void TestCleanup()
        {
            AppDomain.CurrentDomain.FirstChanceException -= FirstChanceExceptionRaised;
        }
        private void FirstChanceExceptionRaised(object sender, FirstChanceExceptionEventArgs e)
        {
            FirstChanceExceptions.Add(e.Exception);
        }
        /// <summary>
        /// Tests that the default behavior of <c>UnityContainer</c> leads to a <c>SynchronizationLockException</c>
        /// being throw on <c>RegisterInstance</c>.
        /// </summary>
        [TestMethod]
        public void UnityDefaultBehaviorRaisesExceptionOnRegisterInstance()
        {
            Container.RegisterInstance<ITest>(this);
            Assert.AreEqual(1, FirstChanceExceptions.Count);
            Assert.IsInstanceOfType(FirstChanceExceptions[0], typeof(SynchronizationLockException));
        }
        /// <summary>
        /// Tests that <c>UnitySafeBehaviorExtension</c> protects against <c>SynchronizationLockException</c>s being
        /// thrown during calls to <c>RegisterInstance</c>.
        /// </summary>
        [TestMethod]
        public void SafeBehaviorPreventsExceptionOnRegisterInstance()
        {
            Container.RemoveAllExtensions();
            Container.AddExtension(new UnitySafeBehaviorExtension());
            Container.AddExtension(new InjectedMembers());
            Container.AddExtension(new UnityDefaultStrategiesExtension());
            Container.RegisterInstance<ITest>(this);
            Assert.AreEqual(0, FirstChanceExceptions.Count);
        }
    }
    public interface ITest { }
