    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    
    namespace Test
    {
        public partial class Form1 : Form
        {
            foo a;
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                a = new foo();
                a.name = "bar";
    
    
    
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                if (a != null && a.name != null)
                    MessageBox.Show(a.name);
                else 
                    MessageBox.Show("");
            }
        }
    
        public class foo
        {
    
            string _name;
            public string name
            {
                get {
                    return _name;
                }
                set {
                    _name = value;
                }
            }
    
            public foo()
            { 
    
            }
        }
    }
