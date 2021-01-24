    private List<string> comboData;
    private DataGridViewComboBoxColumn comboColumn;
    private void Form2_Load(object sender, EventArgs e) {
      comboData = new List<string>();
      comboData.Add("Foo");
      comboData.Add("Bar");
      comboColumn = new DataGridViewComboBoxColumn();
      comboColumn.DataSource = comboData;
      theGrid2.Columns.Add(comboColumn);
      theGrid2.RowCount = 3;
    }
    private void checkData2(string s) { 
      if (!comboData.Contains(s)) {
        comboData.Add(s);
        comboData.Sort();
        comboColumn.DataSource = null;
        comboColumn.DataSource = comboData;
      }
    }
