    DataTable dataTable;
    DataTable comboData;
    public Form2() {
      InitializeComponent();
    }
    private void Form2_Load(object sender, EventArgs e) {
      dataTable = GetTable();
      FillTable(dataTable);
      FillComboTable();
      SetGridColumns(dataGridView1);
      dataGridView1.AutoGenerateColumns = false;
      dataGridView1.DataSource = dataTable;
      dataGridView2.DataSource = dataTable;
    }
    private DataTable GetTable() {
      DataTable dt = new DataTable();
      dt.Columns.Add("id", typeof(int));
      dt.Columns.Add("name", typeof(string));
      dt.Columns.Add("type_id", typeof(int));
      return dt;
    }
    private void FillTable(DataTable dt) {
      dt.Rows.Add(0, "joe", 156);
      dt.Rows.Add(1, "alice", 23);
      dt.Rows.Add(2, "mark", 0);
      dt.Rows.Add(3, "sally", 44);
      dt.Rows.Add(4, "gabe", 133);
    }
    private DataTable GetComboTable() {
      DataTable dt = new DataTable();
      dt.Columns.Add("value", typeof(int));
      dt.Columns.Add("name", typeof(string));
      return dt;
    }
    private void FillComboTable() {
      comboData = GetComboTable();
      comboData.Rows.Add(156, "admin");
      comboData.Rows.Add(23, "user");
      comboData.Rows.Add(44, "database");
      comboData.Rows.Add(133, "system");
      comboData.Rows.Add(0, " ");
    }
    private void SetGridColumns(DataGridView dgv) {
      DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
      col1.HeaderText = "name";
      col1.Name = "name";
      col1.DataPropertyName = "name";
      dgv.Columns.Add(col1);
      DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn {
        HeaderText = "type_id",
        Name = "type_id",
        DataPropertyName = "type_id"
      };
      combo.DataSource = comboData;
      combo.DisplayMember = "name";
      combo.ValueMember = "value";
      dgv.Columns.Add(combo);
    }
    private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e) {
      MessageBox.Show("Data Error: " + e.Exception.Message);
    }
    private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e) {
      if (dataGridView1.IsCurrentCellDirty) {
        dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        dataGridView2.DataSource = null;
        dataGridView2.DataSource = dataTable;
      }
    }
