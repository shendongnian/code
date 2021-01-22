    public partial class Form1 : Form
        {
            private DataTable table;
    
            public Form1()
            {
                InitializeComponent();
                table = new DataTable();
                this.LoadUpDGV();
            }
    
            private void LoadUpDGV()
            {
                table.Columns.Add("Name");
                table.Columns.Add("Age", typeof(int));
    
                table.Rows.Add("Alex", 27);
                table.Rows.Add("Jack", 65);
                table.Rows.Add("Bill", 22);
                table.Rows.Add("Mike", 36);
                table.Rows.Add("Joe", 12);
                table.Rows.Add("Michelle", 43);
                table.Rows.Add("Dianne", 67);
    
                this.dataGridView1.DataSource = table.DefaultView;
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                table.Rows.Add("Jake", 95);
            }
        }
