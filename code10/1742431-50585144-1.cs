    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;
    using System.Xml.Linq;
    namespace WindowsFormsApplication18
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                button1.Click += new EventHandler(openToolStripMenuItem_Click);
            }
            private void openToolStripMenuItem_Click(object sender, EventArgs e)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Text", typeof(string));
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string fileType = ofd.FileName;
                    XDocument xDoc = XDocument.Load(fileType);
                    Boolean first = true;
                    foreach (XElement employee in xDoc.Descendants().Where(x => x.Name.LocalName == "Employee"))
                    {
                        if (first)
                        {
                            foreach (XElement characteristic in employee.Elements())
                            {
                                dt.Columns.Add(characteristic.Name.LocalName, typeof(string));
                            }
                            first = false;
                        }
                        dt.Rows.Add(employee.Elements().Select(x => (string)x).ToArray());
                    }
                    dataGridView1.DataSource = dt;
                }
            }
        }
    }
