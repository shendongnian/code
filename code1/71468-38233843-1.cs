    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var c1 = new GeoCoordinate(0, 0);
            var c2 = c1.CalculateDerivedPosition(1000000, 0);
            Console.Write(c2);
        }
    }
