    public abstract class X
    {
        // "friend" member
        protected X()
        {
        }
        // a bunch of stuff that I didn't feel like shadowing in an interface
    }
    public class Y
    {
        private X _x;
        public Y()
        {
            _x = new ConstructibleX();
        }
        public X GetX()
        {
            return _x;
        }
        private class ConstructibleX : X
        {
            public ConstructibleX()
                : base()
            {}
        }
    }
