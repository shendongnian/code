        namespace StackoverFlow4
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                button1.Text = "UnSelected";
            }
            private void Form1_Load(object sender, EventArgs e)
            {
            }
            private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                button1.Text = "Selected";
                pictureBox1.BackgroundImage = StackoverFlow4.Properties.Resources.tick;
                button1.Text = "Clear Selected";
            }
            private void button1_Click(object sender, EventArgs e)
            {
                listBox1.ClearSelected();
                listBox2.ClearSelected();
                button1.Text = "UnSelected";
                pictureBox1.BackgroundImage = StackoverFlow4.Properties.Resources.cross;
                pictureBox2.BackgroundImage = StackoverFlow4.Properties.Resources.cross;
            }
            private void listBox2_SelectedValueChanged(object sender, EventArgs e)
            {
                pictureBox2.BackgroundImage = StackoverFlow4.Properties.Resources.tick;
                button1.Text = "Clear Selected";
            }
        }
    }
