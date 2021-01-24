    public partial class TestForm : Form
    {
        TestForm2 tf2;
        private string StringInFirstForm = "Blank";
        public TestForm()
        {
            InitializeComponent();
            tf2 = new TestForm2(this);
            tf2.Show();
        }
        public void ChangeVariable(string Whatever)
        {
            StringInFirstForm = Whatever;
            MessageBox.Show("You have changed StringInFirstForm value using method ChangeVariable");
        }
    }
    public partial class TestForm2 : Form
    {
        TestForm tf;
        public TestForm2(TestForm tf)
        {
            InitializeComponent();
            this.tf = tf;
            tf.ChangeVariable("Some String");
        }
    }
