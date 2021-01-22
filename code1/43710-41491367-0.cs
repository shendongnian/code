    using System.Collections.Generic;
    using System.Windows.Forms;
    
    namespace FindTheCheckedBoxes
    {
        public partial class Form1 : Form
        {
            List<TestObject> list = new List<TestObject>();
    
            List<int> positionId = new List<int>();
    
            public Form1()
            {
                InitializeComponent();
                PopulateDataGrid();
    
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if ((bool)row.Cells[0].Value == true)
                        positionId.Add((int)row.Cells[1].Value);
                }
    
                // sets the window title to the columns found ...
                this.Text = string.Join(", ", positionId);
            }
            void PopulateDataGrid()
            {
                list.Add(new TestObject { tick = false, LineNum = 1 });
                list.Add(new TestObject { tick = true, LineNum = 2 });
                list.Add(new TestObject { tick = false, LineNum = 3 });
                list.Add(new TestObject { tick = true, LineNum = 4 });
    
                dataGridView1.DataSource = list;
            }
        }
        class TestObject
        {
            public bool tick { get; set; }
            public int LineNum { get; set; }
        }
    }
