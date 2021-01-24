    private DataTable gridTable;
    private DataTable splitTable;
    public Form1() {
      InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e) {
      gridTable = GetTable();
      FillTable(gridTable);
      splitTable = GetSplitTable(gridTable);
      AddGridColumn();
      dgv1.AutoGenerateColumns = false;
      dgv1.DataSource = splitTable;
      textBox1.Text = "18";
    }
    private void FillTable(DataTable dt) {
      dt.Rows.Add("0-18");
      dt.Rows.Add("19-100");
      dt.Rows.Add("0-100");
      dt.Rows.Add("17-80");
      dt.Rows.Add("15-75");
    }
    private DataTable GetTable() {
      DataTable dt = new DataTable();
      dt.Columns.Add("AgeRange", typeof(string));
      return dt;
    }
    private void AddGridColumn() {
      DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
      col.Name = "AgeRange";
      col.DataPropertyName = "AgeRange";
      col.HeaderText = "Age Range";
      dgv1.Columns.Add(col);
    }
    private void button1_Click(object sender, EventArgs e) {
      string filterString = "";
      DataView dv;
      if (textBox1.Text != "") {
        filterString = string.Format("StartRange <= {0} AND EndRange >= {0}", textBox1.Text);
      }
      dv = new DataView(splitTable);
      dv.RowFilter = filterString;
      dgv1.DataSource = dv;
    }
