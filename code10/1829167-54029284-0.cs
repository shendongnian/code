    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                // Show the dialog.
                DialogResult result = fontDialog1.ShowDialog();
                // See if OK was pressed.
                if (result == DialogResult.OK)
                {
                    // Get Font.
                    Font font = fontDialog1.Font;
                    // Set TextBox properties.
                    this.textBox1.Text = string.Format("Font: {0}", font.Name);
                    this.textBox1.Font = font;
                }
            }
        }
    }
