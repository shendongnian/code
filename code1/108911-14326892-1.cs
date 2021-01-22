    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            DataTable m_dataTable;
            DataTable table { get { return m_dataTable; } set { m_dataTable = value; } }
            private const string m_nameCol = "Name";
            private const string m_choiceCol = "Choice";
            public Form1()
            {
                InitializeComponent();
            }
            class Options
            {
                public int m_Index { get; set; }
                public string m_Text { get; set; }
            }
            private void button1_Click(object sender, EventArgs e)
            {
                table = new DataTable();
                table.Columns.Add(m_nameCol);
                table.Rows.Add(new object[] { "Foo" });
                table.Rows.Add(new object[] { "Bob" });
                table.Rows.Add(new object[] { "Timn" });
                table.Rows.Add(new object[] { "Fred" });
                dataGridView1.DataSource = table;
                if (!dataGridView1.Columns.Contains(m_choiceCol))
                {
                    DataGridViewTextBoxColumn txtCol = new DataGridViewTextBoxColumn();
                    txtCol.Name = m_choiceCol;
                    dataGridView1.Columns.Add(txtCol);
                }
                List<Options> oList = new List<Options>();
                oList.Add(new Options() { m_Index = 0, m_Text = "None" });
                for (int i = 1; i < 10; i++)
                {
                    oList.Add(new Options() { m_Index = i, m_Text = "Op" + i });
                }
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i += 2)
                {
                    DataGridViewComboBoxCell c = new DataGridViewComboBoxCell();
                    //Setup A
                    c.DataSource = oList;
                    c.Value = oList[0].m_Text;
                    c.ValueMember = "m_Text";
                    c.DisplayMember = "m_Text";
                    c.ValueType = typeof(string);
                    ////Setup B
                    //c.DataSource = oList;
                    //c.Value = 0;
                    //c.ValueMember = "m_Index";
                    //c.DisplayMember = "m_Text";
                    //c.ValueType = typeof(int);
                    //Result is the same A or B
                    dataGridView1[m_choiceCol, i] = c;
                }
            }
            private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
                {
                    if (dataGridView1.CurrentCell.ColumnIndex == dataGridView1.Columns.IndexOf(dataGridView1.Columns[m_choiceCol]))
                    {
                        DataGridViewCell cell = dataGridView1[m_choiceCol, e.RowIndex];
                        dataGridView1.CurrentCell = cell;
                        dataGridView1.BeginEdit(true);
                    }
                }
            }
        }
    }
