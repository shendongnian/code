    public partial class DerivedClassA : BaseClass, IInterface
    {
        public void FooBar()
        {
            this.Foo();
            this.Bar();
        }
    }
