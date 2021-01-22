        [TestClass]
        public class NamedCI
        {
            internal interface ITestInterface
            {
                int GetValue();
            }
            internal class TestClassOne : ITestInterface
            {
                public int GetValue()
                {
                    return 1;
                }
            }
            internal class TestClassTwo : ITestInterface
            {
                public int GetValue()
                {
                    return 2;
                }
            }
            internal class ClassToResolve
            {
                public int Value { get; private set; }
                public ClassToResolve([Dependency("ClassTwo")]ITestInterface testClass)
                {
                    Value = testClass.GetValue();
                }
            }
            [TestMethod]
            public void Resolve_NamedCtorDependencyRegisteredLast_InjectsCorrectInstance()
            {
                using (IUnityContainer container = new UnityContainer())
                {
                    container.RegisterType<ITestInterface, TestClassOne>("ClassOne");
                    container.RegisterType<ITestInterface, TestClassTwo>("ClassTwo");
                    container.RegisterType<ClassToResolve>();
                    var resolvedClass = container.Resolve<ClassToResolve>();
                    Assert.AreEqual<int>(2, resolvedClass.Value);
                }
            }
            [TestMethod]
            public void Resolve_NamedCtorDependencyRegisteredFirst_InjectsCorrectInstance()
            {
                using (IUnityContainer container = new UnityContainer())
                {
                    container.RegisterType<ITestInterface, TestClassTwo>("ClassTwo");
                    container.RegisterType<ITestInterface, TestClassOne>("ClassOne");
                    container.RegisterType<ClassToResolve>();
                    var resolvedClass = container.Resolve<ClassToResolve>();
                    Assert.AreEqual<int>(2, resolvedClass.Value);
                }
            }
        }
