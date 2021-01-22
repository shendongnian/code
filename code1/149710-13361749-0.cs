    [TestClass]
    public class UnityContainerTest
    {
        [TestMethod]
        public void RemoveFromContainer()
        {
            UnityContainer container = new UnityContainer();
            MyUnityMember member = new MyUnityMember(5);
            LifetimeManager lifetimeManager = new ContainerControlledLifetimeManager();
            container.RegisterInstance(member, lifetimeManager);
            var resolved = container.Resolve<MyUnityMember>();
            Assert.IsNotNull(resolved);
            lifetimeManager.RemoveValue();
            try
            {
                resolved = container.Resolve<MyUnityMember>();
                Assert.Fail(resolved + " is still in the container");
            }
            catch (ResolutionFailedException)
            {
            }
        }
        public class MyUnityMember
        {
            public MyUnityMember(int x)
            {
                I = x;
            }
            public int I { get; private set; }
        }
    }
