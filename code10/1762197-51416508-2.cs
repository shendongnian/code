    private DateTime TargetTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 9, 45, 00);
    private DataTable GridDT;
    public Form1() {
      InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e) {
      GridDT = GetTable();
      FillTable(GridDT);
      dataGridView1.DataSource = GridDT;
      SetPACol();
    }
    private void SetPACol() {
      for (int i = 0; i < dataGridView1.Rows.Count; i++) {
        dataGridView1_CellValueChanged(this, new DataGridViewCellEventArgs(2, i));
      }
    }
    
    private DataTable GetTable() {
      DataTable dt = new DataTable();
      dt.Columns.Add("Code", typeof(int));
      dt.Columns.Add("Name", typeof(string));
      dt.Columns.Add("Time", typeof(DateTime));
      dt.Columns.Add("P/A", typeof(string));
      return dt;
    }
    private void FillTable(DataTable dt) {
      dt.Rows.Add(1642, "Name1", new DateTime(TargetTime.Year, TargetTime.Month, TargetTime.Day, 9, 47, 00));
      dt.Rows.Add(1642, "Name2", new DateTime(TargetTime.Year, TargetTime.Month, TargetTime.Day, 9, 45, 00));
      dt.Rows.Add(1642, "Name3", new DateTime(TargetTime.Year, TargetTime.Month, TargetTime.Day, 9, 44, 59));
      dt.Rows.Add(1642, "Name4", null);
      dt.Rows.Add(1642, "Name5", new DateTime(TargetTime.Year, TargetTime.Month, TargetTime.Day, 9, 47, 00));
      dt.Rows.Add(1642, "Name6");
    }
