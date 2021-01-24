    public partial class Form1 : Form
    {
        private DataTable table = new DataTable();
        private DataTable newTable;
        public Form1()
        {
            InitializeComponent();
            table.Columns.AddRange(new DataColumn[] {
                new DataColumn("id",typeof(int)),
                new DataColumn("Desc",typeof(string))
            });
            newTable = table.Copy();
            dataGridView1.DataSource = table;
            dataGridView2.DataSource = newTable;
            table.Rows.Add(1, "One");
            table.Rows.Add(2, "Two");
            table.Rows.Add(3, "Three");
            table.Rows.Add(4, "Four");
            table.Rows.Add(5, "Five");
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                try
                {
                    var datarow = ((DataRowView)row.DataBoundItem).Row;
                    newTable.Rows.Add(datarow.ItemArray);
                    dataGridView1.Rows.RemoveAt(row.Index);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
