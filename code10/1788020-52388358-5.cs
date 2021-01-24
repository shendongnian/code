    [TestFixture]
    public class FooTests
    {
        private readonly Foo Foo;
        public FooTests()  
        {
            this.Foo = new Foo();
        }
        
        public overrides Program GetConcrete()
        {
            return this.Foo;
        }
        [Test]
        public void CustomFooMethodTestReturnsFalse()
        {
            var result = this.Foo.CustomFooMethod();
            Assert.IsFalse(result);
        }
    }
