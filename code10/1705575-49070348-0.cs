    using System;
    using System.Data;
    using System.Windows.Forms;
    using System.Data.SqlClient;
    
    namespace WindowsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                dataGridView1.ColumnCount = 3;
                dataGridView1.Columns[0].Name = "Product ID";
                dataGridView1.Columns[1].Name = "Product Name";
                dataGridView1.Columns[2].Name = "Product Price";
    
                string[] row = new string[] { "1", "Product 1", "1000" };
                dataGridView1.Rows.Add(row);
                row = new string[] { "2", "Product 2", "2000" };
                dataGridView1.Rows.Add(row);
                row = new string[] { "3", "Product 3", "3000" };
                dataGridView1.Rows.Add(row);
                row = new string[] { "4", "Product 4", "4000" };
                dataGridView1.Rows.Add(row);
    
                DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
                cmb.HeaderText = "Select Data";
                cmb.Name = "cmb";
                cmb.MaxDropDownItems = 4;
                cmb.Items.Add("True");
                cmb.Items.Add("False");
                dataGridView1.Columns.Add(cmb);
    
            }
        }
    }
