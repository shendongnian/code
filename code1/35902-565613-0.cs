    public class DefaultOrNullChecker<T>  {
        public bool Check(object x) {
            return object.ReferenceEquals(x, null) || x.Equals(default(T));
        }
    }
    [TestFixture]
    public class Tests {
        [Test]  public void when_T_is_reference_type() { 
            Assert.IsFalse(new DefaultOrNullChecker<Exception>().Check(new Exception()));}
        [Test] public void when_T_is_value_type() { 
            Assert.IsFalse(new DefaultOrNullChecker<int>().Check(123)); }
        [Test] public void when_T_is_null() {
            Assert.IsTrue(new DefaultOrNullChecker<Exception>().Check(null));}
        [Test] public void when_T_is_default_value() { 
            Assert.IsTrue(new DefaultOrNullChecker<int>().Check(0)); }
    }
