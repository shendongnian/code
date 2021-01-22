    public class Derived3 : Base
    {
        public override event EventHandler Foo
        {
            add { base.Foo += value; }
            remove { base.Foo -= value; }
        }
        protected override void RaiseFoo()
        {
            Foo?.Invoke(this, EventArgs.Empty);
        }
    }
