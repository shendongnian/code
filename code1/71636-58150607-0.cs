    public class Base 
    {
        public virtual event EventHandler Foo;
        public void Bar()
        {
            RaiseFoo();
        }
        protected virtual void RaiseFoo()
        {
            Foo?.Invoke(this, EventArgs.Empty);
        }
    }
    public class Derived : Base
    {
        // In this case we use the base Foo as a backing store.
        public override event EventHandler Foo
        {
            add { base.Foo += value; }
            remove { base.Foo -= value; }
        }
    }
    public class Derived2 : Base
    {
        public override event EventHandler Foo;
        // In this case we raise the overriden Foo.
        protected override void RaiseFoo()
        {
            Foo?.Invoke(this, EventArgs.Empty);
        }
    }
    class Test
    {
        static void Main()
        {
            Base x = new Derived();
            x.Foo += (sender, e) => { };
            x.Bar();
            Base x2 = new Derived2();
            x2.Foo += (sender, e) => { };
            x2.Bar();
        }
    }
