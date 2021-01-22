    using System.Text;
    using System.Windows.Forms;
    using System;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                textBox1.Text = "mail@mail.com; mail2@mail.com; mail3@mail.com";
            }
            private void textBox1_Click(object sender, EventArgs e)
            {
                int nextSpaceIndex = textBox1.Text.Substring(textBox1.SelectionStart).IndexOf(' ');
                int firstSpaceIndex = textBox1.Text.Substring(0, textBox1.SelectionStart).LastIndexOf(' ');
                nextSpaceIndex = nextSpaceIndex == -1 ? textBox1.Text.Length : nextSpaceIndex + textBox1.SelectionStart;
                firstSpaceIndex = firstSpaceIndex == -1 ? 0 : firstSpaceIndex;
                textBox1.SelectionStart = firstSpaceIndex;
                textBox1.SelectionLength = nextSpaceIndex - firstSpaceIndex;
            }
        }
    }
