    public class GridviewData
    {
        public string ProductId{set;get;}
        public string ProductName { set; get; }
        public string ExpireDate { set; get; }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = comboBox1.SelectedItem.ToString();
            List<string> dataList = selectedItem.Split('-').ToList();
            GridviewData data = new GridviewData();
            data.ProductId = dataList[0];
            data.ProductName = dataList[1];
            data.ExpireDate = dataList[2];
            List<GridviewData> gridviewList = new List<GridviewData>();
            gridviewList.Add(data);
            dataGridView1.DataSource = gridviewList;
        }
    }
