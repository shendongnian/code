    DataTable gridTable;
    DataView dv;
    public Form1() {
      InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e) {
      gridTable = GetTable();
      FillTable(gridTable);
      dataGridView1.DataSource = gridTable;
      SetComboBox();
    }
    private void SetComboBox() {
      comboBox1.Items.Add("No Filter");
      comboBox1.Items.Add("Class A");
      comboBox1.Items.Add("Class B");
      comboBox1.Items.Add("Class C");
      comboBox1.SelectedIndex = 0;
    }
    private DataTable GetTable() {
      DataTable dt = new DataTable();
      dt.Columns.Add("FName", typeof(string));
      dt.Columns.Add("LName", typeof(string));
      dt.Columns.Add("Class", typeof(string));
      return dt;
    }
    private void FillTable(DataTable dt) {
      for (int i = 1; i < 5; i++) {
        dt.Rows.Add("FName" + i, "LName" + i, "Class A");
        dt.Rows.Add("FName" + i, "LName" + i, "Class B");
        dt.Rows.Add("Class" + i, "Class" + i, "Class C");
      }
    }
    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
      dv = new DataView(gridTable);
      if (comboBox1.Text == "No Filter")
        dv.RowFilter = "";
      else
        dv.RowFilter = "Class = '" + comboBox1.Text + "'";
      dataGridView1.DataSource = dv;
    }
