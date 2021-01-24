    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FillTable();
        }
        private void FindBT_Click(object sender, EventArgs e)
        {
            FindExpiring();
        }
        private void FindExpiring()
        {
            var nowPlusOneWeek = DateTime.Now + new TimeSpan(7, 0, 0, 0);
            var expiringItems = InventoryList.Rows.Cast<DataGridViewRow>().
                Where(x => x.Cells[0].Value != null &&
                DateTime.ParseExact(x.Cells[3].Value.ToString(), "dd/MM/yyyy",
                CultureInfo.InvariantCulture) <= nowPlusOneWeek);
            var Expiry = new StringBuilder();
            foreach (var item in expiringItems)
                Expiry.Append("Nearing Expiry: " + item.Cells[0].Value.ToString() + "\n");
            MessageBox.Show(Expiry.ToString());
        }
        void FillTable()
        {
            Random RND = new Random();
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("InventoryID", typeof(int));
            dt1.Columns.Add("ItemID", typeof(int));
            dt1.Columns.Add("Quantity", typeof(int));
            dt1.Columns.Add("ExpityDate", typeof(string));
            for (int i = 0; i < 10; i++)
            {
                DataRow dr1 = dt1.NewRow();
                dr1["InventoryID"] = i;
                dr1["ItemID"] = 1;
                dr1["Quantity"] = 20;
                dr1["ExpityDate"] = (DateTime.Now + new TimeSpan(RND.Next(20), 0, 0, 0)).ToString("dd/MM/yyyy");
                dt1.Rows.Add(dr1.ItemArray);
            }
            InventoryList.DataSource = dt1;
        }
    }
