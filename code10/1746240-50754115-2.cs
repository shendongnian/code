    List<OriginSet> originList;
    public Form1() {
      InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e) {
      FillList();
      SetGridProperties();
      dataGridView1.DataSource = originList;
    }
    private void FillList() {
      originList = new List<OriginSet> {
        new OriginSet("Origin 0", new Origin(true, true), new Origin(true, true), new Origin(true, true)),
        new OriginSet("Origin 1", new Origin(true, false), new Origin(true, false), new Origin(true, false)),
        new OriginSet("Origin 2", new Origin(false, false), new Origin(false, false), new Origin(false, false))
      };
    }
    private void SetGridProperties() {
      DataGridViewTextBoxColumn txtCol = new DataGridViewTextBoxColumn();
      txtCol.HeaderText = "Origin";
      txtCol.DataPropertyName = "OriginType";
      dataGridView1.Columns.Add(txtCol);
      dataGridView1.Columns.Add(GetCheckBoxCol("Data A", "originA_State"));
      dataGridView1.Columns.Add(GetCheckBoxCol("Data B", "originB_State"));
      dataGridView1.Columns.Add(GetCheckBoxCol("Data C", "originC_State"));
      dataGridView1.AutoGenerateColumns = false;
    }
    private DataGridViewCheckBoxColumn GetCheckBoxCol(string name, string dataname) {
      DataGridViewCheckBoxColumn chckCol = new DataGridViewCheckBoxColumn();
      chckCol.Name = name;
      chckCol.DataPropertyName = dataname;
      chckCol.ThreeState = true;
      return chckCol;
    }
