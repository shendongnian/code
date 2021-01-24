    public Form1() {
      InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e) {
      DataTable gridDT = GetGridTable();
      FillGridTable(gridDT);
      DataGridViewComboBoxColumn combocol = GetComboColumn(gridDT);
      dataGridView1.Columns.Add(combocol);
      dataGridView1.DataSource = gridDT;
    }
    private DataTable GetGridTable() {
      DataTable dt = new DataTable();
      dt.Columns.Add("Col1", typeof(string));
      dt.Columns.Add("Col2", typeof(string));
      dt.Columns.Add("Quantity", typeof(decimal));
      return dt;
    }
    private DataTable GetComboTable() {
      DataTable dt = new DataTable();
      dt.Columns.Add("index", typeof(int));
      dt.Columns.Add("Quantity", typeof(decimal));
      return dt;
    }
    private void FillGridTable(DataTable dt) {
      dt.Rows.Add("C0R0", "C1R0", 12.5);
      dt.Rows.Add("C0R1", "C1R1", 2);
      dt.Rows.Add("C0R2", "C1R2", 33.5);
      dt.Rows.Add("C0R3", "C1R3", 1);
      dt.Rows.Add("C0R4", "C1R4", 22.5);
      dt.Rows.Add("C0R5", "C1R5", 1);
      dt.Rows.Add("C0R6", "C1R6", 12.5);
    }
    private DataGridViewComboBoxColumn GetComboColumn(DataTable dt) {
      DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
      combo.HeaderText = "Quantity";
      combo.Name = "combo";
      combo.DataPropertyName = "Quantity";
      combo.DisplayMember = "Quantity";
      DataTable comboDT = GetComboTable();
      //DataTable comboDT = GetFullcomboDT();
      int index = 0;
      foreach (DataRow dr in dt.Rows) {
        if (NewValue((decimal)dr["Quantity"], comboDT)) {
          comboDT.Rows.Add(index, dr["Quantity"]);
        }
      }
      combo.DataSource = comboDT;
      return combo;
    }
    private bool NewValue(decimal value, DataTable dt) {
      foreach (DataRow row in dt.Rows) {
        if (((decimal)row["Quantity"]) == value) {
          return false;
        }
      }
      return true;
    }
    private DataTable GetFullcomboDT() {
      DataTable dt = new DataTable();
      dt.Columns.Add("index", typeof(int));
      dt.Columns.Add("Quantity", typeof(decimal));
      decimal currentValue = 1.0m;
      int index = 0;
      for (int i = 0; i < 20; i++) {
        dt.Rows.Add(index, currentValue);
        currentValue += 0.5m;
        index++;
      }
      return dt;
    }
