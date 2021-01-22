    class BaseClass {
        public virtual Vector2 Position {
            get { return new Vector2(){X=0,Y=0}; }
        }
    }
    class Class : BaseClass {
        public override Vector2 Position {
            get { return new Vector2(){X=10,Y=10}; }
        }
    }
