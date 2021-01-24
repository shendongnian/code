    DataTable GridTable;
    public Form1() {
      InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e) {
      GridTable = GetDataTable();
      FillTable(GridTable);
      AddExpressionColumn(GridTable);
      dataGridView1.DataSource = GridTable;
      dataGridView1.Columns["Column3"].Visible = false;
    }
    private DataTable GetDataTable() {
      DataTable dt = new DataTable();
      dt.Columns.Add("Column1", typeof(string));
      dt.Columns.Add("Column2", typeof(string));
      dt.Columns.Add("Column3", typeof(decimal));
      return dt;
    }
    private void FillTable(DataTable dt) {
      dt.Rows.Add("a", "b", 2000000m);
      dt.Rows.Add("q", "r", 250000m);
      dt.Rows.Add("s", "t", 185000m);
      dt.Rows.Add("m", "w", 400000m);
      dt.Rows.Add("o", "p", 750000m);
    }
    private void AddExpressionColumn(DataTable dt) {
      decimal max = GetMaxValue(dt);
      DataColumn expCol = new DataColumn("Result", typeof(decimal));
      dt.Columns.Add(expCol);
      string expressionString = "Column3 / " + max.ToString();
      expCol.Expression = expressionString;
     
    }
    private decimal GetMaxValue(DataTable dt) {
      decimal max = 1;
      foreach (DataRow dr in dt.Rows) {
        if (max < (decimal)dr.ItemArray[2])
          max = (decimal)dr.ItemArray[2];
      }
      return max;
    }
