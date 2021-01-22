    public abstract class A
    {
        public abstract int X { get; }
    }
    public class B : A
    {
        public override int X { get { return 0; } }
    }
    /*public class C : B  //doesn't compile because can't override with setter
    {
        private int _x;
        public override int X { get { return _x; } set { _x = value; } }
    }*/
    public abstract class C : B  //just here to seal away the read-only limitation
    {
        public sealed override int X { get { return base.X; }  }
    }
    public class D : C  //class you wanted to write
    {
        private int _x;
        public new virtual int X { get { return base.X; } set { this._x = value; } }
    }
