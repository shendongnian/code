    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        // Save order
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable("table");
            var query = from DataGridViewColumn col in dataGridView1.Columns
                        orderby col.DisplayIndex
                        select col;
            foreach (DataGridViewColumn col in query)
            {
                dt.Columns.Add(col.Name);
            }
            dt.WriteXmlSchema(@"c:\temp\columnorder.xml");
        }
        // Restore order
        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.ReadXmlSchema(@"c:\temp\columnorder.xml");
            int i = 0;
            foreach (DataColumn col in dt.Columns)
            {
                dataGridView1.Columns[col.ColumnName].DisplayIndex = i;
                i++;
            }
        }
    }
