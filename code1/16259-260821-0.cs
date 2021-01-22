    using System;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                this.textBox1.ShortcutsEnabled = false;
                this.textBox1.KeyUp += new KeyEventHandler(textBox1_KeyUp);
            }
            void textBox1_KeyUp(object sender, KeyEventArgs e)
            {
                if (e.Control == true && e.KeyCode == Keys.X)
                    MessageBox.Show("Overriding ctrl+x");
            }
        }
    }
