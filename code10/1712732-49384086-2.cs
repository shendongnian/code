     public partial class Form1 : Form
     {
        public Form1()
        {
            InitializeComponent();
            CustomNumericUpDown nudTest = new CustomNumericUpDown();
            nudTest.QueryCancelValueChanging += NudTest_QueryCancelValueChanging;
        }
        private bool NudTest_QueryCancelValueChanging()
        {
            return true;/* Replace by custom condition here*/
        }
    }
