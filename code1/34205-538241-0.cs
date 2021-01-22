    public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                this.MdiChildActivate += new EventHandler(Form1_MdiChildActivate);
            }
    
            void Form1_MdiChildActivate(object sender, EventArgs e)
            {
                MessageBox.Show("Activated");
            }
    
            private void addToolStripMenuItem_Click(object sender, EventArgs e)
            {
                Form form2 = new Form2();
                form2.MdiParent = this;
                form2.Show();
            }
        }
