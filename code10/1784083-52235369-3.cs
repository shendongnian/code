    public partial class TestForm : Form
    {
        TestForm2 tf2; //Create global Variable for Second form which will be accessible from whole First Form Class
        public string StringProperty
        {
            //Since there is no get{ } user can only SET property and when he does that property gets passed value and put that value into private variable in this class
            set
            { 
                StringInFirstForm = value;
                MessageBox.Show("You have changed value of StringInFristForm using property named StringProperty");
            }
        }
        private string StringInFirstForm = "Blank";
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
            tf.StringProperty = "I have changed string";
            string Test = tf.StringProperty; // This will return error which will say that property could only be set but not get
        }
    }
