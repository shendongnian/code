    List<NpcDrop> fullNPCDropsList;
    DataTable gridTable;
    public Form1() {
      InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e) {
      fullNPCDropsList = GetData1();
      dgvListData.DataSource = fullNPCDropsList;
      gridTable = GetData2();
      dgvDataTableData.DataSource = gridTable;
    }
    private List<NpcDrop> GetData1() {
      List<NpcDrop> drop = new List<NpcDrop>();
      int start = 201000;
      for (int i = 0; i < 100; i++) {
        drop.Add(new NpcDrop(++start));
      }
      return drop;
    }
    private DataTable GetData2() {
      DataTable dt = new DataTable();
      dt.Columns.Add("ID", typeof(string));
      int start = 201000;
      for (int i = 0; i < 100; i++) {
        dt.Rows.Add((++start).ToString());
      }
      return dt;
    }
    private void txtListSearchBox_TextChanged(object sender, EventArgs e) {
      if (txtListSearchBox.Text == "") {
        dgvListData.DataSource = fullNPCDropsList;
      }
      else {
        if (int.TryParse(txtListSearchBox.Text, out int value)) {
          List<NpcDrop> filterList = fullNPCDropsList.FindAll(x => x.ID.Equals(value));
          dgvListData.DataSource = filterList;
        }
      }
    }
    private void txtDTSearchBox_TextChanged(object sender, EventArgs e) {
      if (txtDTSearchBox.Text == "") {
        dgvDataTableData.DataSource = gridTable;
      }
      else {
        DataView filterData = new DataView(gridTable);
        filterData.RowFilter = "ID LIKE '%" + txtDTSearchBox.Text + "%'";
        dgvDataTableData.DataSource = filterData;
      }
    }
