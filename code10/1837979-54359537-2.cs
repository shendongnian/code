    private DataTable gridTable;
   
    public Form1() {
      InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e) {
      gridTable = GetTable();
      FillTable(gridTable);
      dgv1.DataSource = gridTable;
      textBox1.Text = "18";
    }
    private void FillTable(DataTable dt) {
      dt.Rows.Add("0-18");
      dt.Rows.Add("19-100");
      dt.Rows.Add("0-100");
      dt.Rows.Add("17-80");
      dt.Rows.Add("18-80");
    }
    private DataTable GetTable() {
      DataTable dt = new DataTable();
      dt.Columns.Add("AgeRange", typeof(string));
      return dt;
    }
    private void button1_Click(object sender, EventArgs e) {
      if (textBox1.Text == "") {
        dgv1.DataSource = gridTable;
        return;
      }
      dgv1.DataSource = GetFilterTable();
    }
