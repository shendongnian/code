        public MyClass()
        {
            InitializeComponent();
            textBox1.LostFocus += new EventHandler(testBox1_LostFocus);
        }
        void testBox1_LostFocus(object sender, EventArgs e)
        {
            // do stuff
        }
