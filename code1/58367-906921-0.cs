    public partial class Form1 : Form
    {
        public enum BlahEnum
        { 
            Red,
            Green,
            Blue,
            Purple
        }
        public Form1()
        {
            InitializeComponent();
            comboBox1.DataSource = Enum.GetValues(typeof(BlahEnum));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = BlahEnum.Blue;
        }
    }
