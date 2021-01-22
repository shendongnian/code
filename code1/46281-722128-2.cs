    class BaseClass {
        private Vector2 _position;
        public BaseClass() {
            _position = new Vector2(){X=0,Y=0};
        }
        protected BaseClass(Vector2 initialPosition) {
            _position = initialPosition;
        }
        public Vector2 Position {
            get { return _position; }
            set { _position = value; }
        }
    }
    class Class : BaseClass {
        public Class() : base(new Vector2(){X=10,Y=10}) {
        }
    }
