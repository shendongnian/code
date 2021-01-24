    private DataGridView MyDataGridView = new DataGridView();
    public Form1()
    {
        InitializeComponent();
        SetupDataGridView();
    }
    private void SetupDataGridView()
    {
        this.Controls.Add(MyDataGridView);
        MyDataGridView.ColumnCount = 2;
        MyDataGridView.Name = "MyDataGridView";
        MyDataGridView.Location = new Point(10, 10);
        MyDataGridView.Size = new Size(500, 300);
        MyDataGridView.Columns[0].Name = "ID";
        MyDataGridView.Columns[1].Name = "Value";
        MyDataGridView.Columns.Add(new DataGridViewCheckBoxColumn { Name = "Default" });
        MyDataGridView.Columns.Add(new DataGridViewCheckBoxColumn { Name = "Delete" });
        MyDataGridView.Rows.Add("1", "one", true, true);
        MyDataGridView.Rows.Add("2", "two", false, true);
        MyDataGridView.Rows.Add("3", "three", true, false);
        MyDataGridView.CellContentClick += MyDataGridView_CellContentClick;
    }
    private void MyDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        // get value of checkbox
        var checkBox = MyDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;
        var isCheck = checkBox?.Value;
        var check = isCheck == null ? false : bool.Parse(isCheck.ToString());
        if (isCheck != null)            
            checkBox.Value = !check;        // change checkbox value
        if (e.ColumnIndex == 3 && check)
        {
            DialogResult dialogResult = MessageBox.Show("Are you Sure", 
                "Delete Row", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MyDataGridView.Rows.RemoveAt(e.RowIndex);
            }
        }
    }
