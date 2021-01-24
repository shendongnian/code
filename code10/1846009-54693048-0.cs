        class MyClass
        {
            public string Name { get; set; }
            public MyClass ShallowCopy()
            {
                return (MyClass)this.MemberwiseClone();
            }
        }
        //Copy of original state of object
        private MyClass _orig;
        public Form1()
        {
            InitializeComponent();
            //In your case this comes in via the constructor?
            MyClass o = new MyClass();
            o.Name = "hi";
            _orig = o.ShallowCopy();
     ...
