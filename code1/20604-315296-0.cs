    public enum Test
    {
        One, Two, Three
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.comboBox1.DataSource = Enum.GetNames(typeof(Test));
        }
        public Test Test
        {
            get 
            {
                return (Test)Enum.Parse(typeof(Test), this.comboBox1.Text);
            }
            set
            {
                this.comboBox1.Text = value.ToString();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.Test.ToString());
            this.Test = Test.Two;
            MessageBox.Show(this.Test.ToString());
        }
    }
