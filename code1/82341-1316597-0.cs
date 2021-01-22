        public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        class Calculator
        {
            List<int> values = new List<int>();
            public Calculator Add(int value)
            {
                values.Add(value);
                return this;
            }
            public int Count()
            {
                return values.Count;                
            }
            public int Sum()
            {
                return values.Sum();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //returns 3
            int sum =
                new Calculator()
                .Add(1)
                .Add(2)
                .Sum();
        }
    }
