    protected ICustomControl CustomControl { get; set; }
        public Form1()
        {
            InitializeComponent();
            CustomControl = this.customControl1;
            CustomControl.MyProperty = "Hello World!"; // Access everything through here.
        }
