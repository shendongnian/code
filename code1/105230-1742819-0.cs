    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using System.IO;
    
    namespace LinqTests
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            public String[]
                Content;
            public String
            Value;
    
            private void button1_Click(object sender, EventArgs e)
            {
                Value = textBox1.Text;
    
                OpenFileDialog ofile = new OpenFileDialog();
                ofile.Title = "Open File";
                ofile.Filter = "All Files (*.*)|*.*";
    
                if (ofile.ShowDialog() == DialogResult.OK)
                {
                    Content =
                           File.ReadAllLines(ofile.FileName);
    
                    IEnumerable<String> Query =
                        from instance in Content
                        where instance.Trim() == Value.Trim()
                        orderby instance
                        select instance;
                    
                    foreach (String Item in Query)
                        label1.Text +=
                            Item + Environment.NewLine;
                }
                else Application.DoEvents();
    
                ofile.Dispose();
            }
        }
    }
