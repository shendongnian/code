    public partial class Form1 : Form
    {
        private string[] comboBox1Range = new[] { "A", "B", "C", "D" };
        private string[] comboBox2RangeA = new[] { "A1", "A2", "A3", "A4" };
        private string[] comboBox2RangeB = new[] { "B1", "B2", "B3", "B4" };
        private string[] comboBox2RangeC = new[] { "C1", "C2", "C3", "C4" };
        private string[] comboBox2RangeD = new[] { "D1", "D2", "D3", "D4" };
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox1.Items.AddRange(comboBox1Range);
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboBox1.SelectedItem as string;
            switch (selectedValue)
            {
                case "A":
                    comboBox2.Items.Clear();
                    comboBox2.Items.AddRange(comboBox2RangeA);
                    break;
                case "B":
                    comboBox2.Items.Clear();
                    comboBox2.Items.AddRange(comboBox2RangeB);
                    break;
                case "C":
                    comboBox2.Items.Clear();
                    comboBox2.Items.AddRange(comboBox2RangeC);
                    break;
                case "D":
                    comboBox2.Items.Clear();
                    comboBox2.Items.AddRange(comboBox2RangeD);
                    break;
            }
        }
    }
