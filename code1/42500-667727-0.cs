        public partial class Form1 : Form
        {
            private DataTable mainTable;
            public Form1()
            {
                InitializeComponent();
                this.mainTable = this.CreateTestTable();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                for (int i = 1; i <= 10; i++)
                {
                    this.mainTable.Rows.Add(String.Format("Person{0}", i), i * i);
                }
    
                this.dataGridView1.DataSource = this.mainTable;
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                DataTable newTable = this.CreateTestTable();
                for (int i = 1; i <= 15; i++)
                {
                    newTable.Rows.Add(String.Format("Person{0}", i), i + i);
                }
                this.mainTable.Merge(newTable);
            }
    
            private DataTable CreateTestTable()
            {
                var result = new DataTable();
                result.Columns.Add("Name");
                result.Columns.Add("Age", typeof(int));
                result.PrimaryKey = new DataColumn[] { result.Columns["Name"] };
    
                return result;
    
            }
        }
