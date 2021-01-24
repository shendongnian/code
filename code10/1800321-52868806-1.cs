    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethodProduct()
        {
            Product p1 = new Product{ Id=1, Name="Foo" };
            Product p2 = new Product{ Id=1, Name="Foo" };
            Assert.AreEqual( p1, p2 );
        }
    
        [Test]
        public void TestMethodProduct2()
        {
            Product2 p1 = new Product2{ Id=1, Name="Foo" };
            Product2 p2 = new Product2{ Id=1, Name="Foo" };
            Assert.AreEqual( p1, p2 );
        }
    }
