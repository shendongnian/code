    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Age", typeof(int));
            table.Rows.Add("John", 25);
            table.Rows.Add("Jack", 34);
            table.Rows.Add("Mike", 17);
            table.Rows.Add("Mark", 54);
            table.Rows.Add("Frank", 37);
            this.dataGridView1.DataSource = table;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var table = this.dataGridView1.DataSource as DataTable;
            table.DefaultView.RowFilter = "Age > 30";
        }
