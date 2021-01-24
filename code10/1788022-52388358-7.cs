    [TestFixture]
    [Ignore]
    public class ProgramTests
    {
         public virtual Program GetConcrete()
         {
             throw new NotImplementedException();
         }
        [Test]
        public void BaseMethodTestReturnsFalse()
        {
            var result = GetConcrete().BaseMethod();
            Assert.IsFalse(result);
        }
    }
