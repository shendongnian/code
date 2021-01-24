    namespace test1
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Form2 frm = new Form2();
            frm.checkBox1.Checked = Properties.Settings.Default.checkB;
            if (frm.checkBox1.CheckState == CheckState.Checked)
            {
                button1.Visible = false;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show(this); 
        }
        private void button1_Click(object sender, EventArgs e)
        {
        }
        private void button2_Click(object sender, EventArgs e)
        {
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
      }
    }
