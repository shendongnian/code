    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (ControlEventSuspender.Suspend(comboBox1))
            {
                comboBox1.SelectedIndex = 3; // SelectedIndexChanged does not fire
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1; // clear selection, SelectedIndexChanged fires
        }
        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 3; // SelectedIndexChanged fires
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("index changed fired");
            System.Media.SystemSounds.Beep.Play();
        }
    }
