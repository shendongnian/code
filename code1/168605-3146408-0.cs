    public class Foo {
        public static const int DefaultSpeed = 100;
        private int _speed = DefaultSpeed;
        [DefaultValue(DefaultSpeed)]
        public int Speed { get { return _speed; } set { _speed = value; } }
    }
----
        public class Foo {
            public static Color DefaultForecolor { get {return SystemColors.WindowText; }}
            private Color _forecolor = DefaultForecolor;
            [DefaultValue(DefaultForeColor)]
            public Color Forecolor { get { return _forecolor; } set { _forecolor = value; } }
        }
