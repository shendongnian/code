    public partial class TestForm : Form
    {
        TestForm2 tf2; //Create global Variable for Second form which will be accessible from whole First Form Class
        public string StringInFirstForm = "Blank"; //Need to be public
        public TestForm()
        {
            InitializeComponent();
            tf2 = new TestForm2(this); //Assign new object(form) to globally created variable(Second form)
            tf2.Show(); //Important to use Show not ShowDialog since if you use ShowDialog it will stop further code from executing
        }
    }
    public partial class TestForm2 : Form
    {
        TestForm tf;
        public TestForm2(TestForm tf)
        {
            InitializeComponent();
            this.tf = tf;
            tf.StringInFirstForm = "I have changed string";
        }
    }
