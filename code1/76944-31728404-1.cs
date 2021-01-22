    namespace Test
    {
        public partial class Form2 : Form1
        {
            public Form2(string foo) : base(foo)
            {
                //you can use "foo" here even if it is passed to base class too
                InitializeComponent();
            }
        }
    }
