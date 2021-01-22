    #if DEBUG
    
    using NUnit.Framework;
    
    public partial class TheClassBeingTested
    {
        internal int NUnit_TheMethodToBeTested()
        {
            return TheMethodToBeTested();
        }
    }
    
    [TestFixture]
    public class ClassTests
    {
        [Test]
        public void TestMethod()
        {
            var tc = new TheClassBeingTested();
            Assert.That(tc.NUnit_TheMethodToBeTested(), Is.EqualTo(-1));
        }
    }
    
    #endif
