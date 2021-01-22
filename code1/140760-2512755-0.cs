    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                this.KeyPreview = true;
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                this.comboBox1.DataSource = CreateItems();
                
            }
    
    
            private List<string> CreateItems()
            {
                List<string> lst = new List<string>();
                lst.Add("One");
                lst.Add("Two");
                lst.Add("Three");
                lst.Add("Four");
                return lst;
            }
    
            private void comboBox1_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyData == Keys.Enter)
                {
                    if (comboBox1.SelectedIndex == comboBox1.Items.Count-1)
                    {
                        comboBox1.SelectedIndex = 0;
                        return;
                    }
    
                    if (comboBox1.SelectedIndex >=0 & comboBox1.SelectedIndex< comboBox1.Items.Count-1)
                    {
    
                        comboBox1.SelectedIndex = comboBox1.SelectedIndex+1;
                    }
    
                }
            }
    
        }
    }
