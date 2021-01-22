    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
                for (int i = 0; i < 100; i++)
                {
                    comboBox1.Items.Add("Item " + i);
                }
    
            }
    
            private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                this.ActiveControl = null;
            }
        }
    }
