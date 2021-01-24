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
      dt.Columns.Add("Column3", typeof(int));
      return dt;
    }
    private void FillTable(DataTable dt) {
      dt.Rows.Add("a", "b", 2000000);
      dt.Rows.Add("q", "r", 250000);
      dt.Rows.Add("s", "t", 185000);
      dt.Rows.Add("m", "w", 400000);
      dt.Rows.Add("o", "p", 750000);
    }
    private void AddExpressionColumn(DataTable dt) {
      DataColumn expCol = new DataColumn("Result", typeof(decimal));
      dt.Columns.Add(expCol);
      string expressionString = "Column3 / " + GetMaxValue(dt).ToString();
      expCol.Expression = expressionString;
    }
    private int GetMaxValue(DataTable dt) {
      int max = (int)dt.Compute("Max(Column3)", "");
      if (max == 0)
        return 1;
      return max;
    }
