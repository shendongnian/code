    [Trait("Order", "")]   
    [TestCaseOrderer(DependencyOrderer.TypeName, DependencyOrderer.AssemblyName)]
    public partial class OrderTests
    {
        [Fact]        
        public void Test0()
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
        }
        [Fact]
        [TestDependency("Test1", "Test0")]
        public void Test3()
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
        }
     }
    [Trait("Order", "")]
    public partial class OrderTests
    {
        [Fact]
        public void Test2()
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));            
        }
        [Fact]
        [TestDependency("Test0")]
        public void Test1()
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
        }
    }
