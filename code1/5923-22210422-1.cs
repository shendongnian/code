    public abstract class A
    {
        public abstract int X { get; }
    }
    public class B : A
    {
        public override int X { get { return 0; } }
    }
    /*public class C : B  //class you want to write but won't compile because can't override with setter
    {
        private int _x;
        public override int X { get { return _x; } set { _x = value; } }
    }*/
    public abstract class C : B  //abstract intermediate layer
    {
        public sealed override int X { get { return this.XGetter; }  }
        protected abstract int XGetter { get; }
    }
    public class D : C  //class you want to write that will compile
    {
        private int _x;
        protected sealed override int XGetter { get { return this.X; } }
        public new virtual int X { get { return this._x; } set { this._x = value; } }
    }
