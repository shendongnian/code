    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            numericUpDown1.Value = someChip1.NumberInputPins;
            numericUpDown2.Value = someChip1.NumberOutputPins;
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            someChip1.NumberInputPins = (int)numericUpDown1.Value;
        }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            someChip1.NumberOutputPins = (int)numericUpDown2.Value;
        }
    }
