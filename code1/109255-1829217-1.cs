    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
                List<TestObject> objects = new List<TestObject>
                    {
                            new TestObject("1", "object1", "first"),
                            new TestObject("2", "object2", "nada"),
                            new TestObject("3", "object3", "Hello World!"),
                            new TestObject("4", "object4", "last")
                    };
    
                dataGridView1.Columns.Add("ColID", "ID");
                dataGridView1.Columns.Add("ColName", "Name");
                dataGridView1.Columns.Add("ColInfo", "Info");
    
                foreach (TestObject testObject in objects)
                {
                    int row = dataGridView1.Rows.Add();
                    dataGridView1.Rows[row].Cells["ColID"].Value = testObject.ID;
                    dataGridView1.Rows[row].Cells["ColName"].Value = testObject.Name;
                    dataGridView1.Rows[row].Cells["ColInfo"].Value = testObject.Info;
                    dataGridView1.Rows[row].Tag = testObject;
                }
    
                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    comboBox1.Items.Add(col);
                }
    
                comboBox1.ValueMember = "HeaderText";
                comboBox1.SelectedIndex = 0;
            }
    
            private void textBox1_TextChanged(object sender, EventArgs e)
            {
                dataGridView1.ClearSelection();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
    
                    if (row.Cells[((DataGridViewColumn)comboBox1.SelectedItem).Name].Value == null)
                    {
                        continue;
                    }
                    if (row.Cells[((DataGridViewColumn)comboBox1.SelectedItem).Name].Value.ToString().Equals(
                            textBox1.Text,StringComparison.InvariantCultureIgnoreCase))
                    {
                        row.Selected = true;
                        return;
                    }
                }
            }
        }
    }
    
    public class TestObject
    {
        public TestObject(string id, string name, string info)
        {
            ID = id;
            Name = name;
            Info = info;
        }
    
        public string ID { get; set; }
        public string Info { get; set; }
        public string Name { get; set; }
    }
