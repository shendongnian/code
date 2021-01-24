    public partial class Form1 : Form
    {
        DataTable dt = new DataTable();
        public Form1()
        {
            InitializeComponent();
            DataColumn productID = new DataColumn();
            productID.ColumnName = "Product ID";
            dt.Columns.Add(productID);
            dt.Columns.Add("Product Name");
            dt.Columns.Add("Expire Date");
            dt.PrimaryKey = new DataColumn[] {productID };//if you want to set primary key for dataTable upon productID
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedItem = comboBox1.SelectedItem.ToString();
                List<string> data = selectedItem.Split('-').ToList();
                dt.Rows.Add(new object[] { data[0], data[1], data[2] });
                dataGridView1.DataSource = dt;
            }
            catch(Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
    }
