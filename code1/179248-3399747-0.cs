    private void Form1_Load(object sender, EventArgs e)
    {
        dataGridView1.DataSource = MyDataTable;
    }
    private string _fileName = "MyCache.xml";
    private DataTable _myDataTable;
    public DataTable MyDataTable
    {
        get
        {
            if (_myDataTable == null)
            {
                _myDataTable = new DataTable();
                if (File.Exists(_fileName))
                    _myDataTable.ReadXml(_fileName);
                else
                    InitDataTable(_myDataTable);
            }
            return _myDataTable;
        }
    }
    private void InitDataTable(DataTable table)
    {
        table.TableName = "MyTable";
        table.Columns.Add("Date", typeof(DateTime));
        table.Columns.Add("Caller", typeof(string));
        table.Columns.Add("Result", typeof(string));
    }
    // Have your add code call this method!
    private void AddValue(DateTime date, string caller, string result)
    {
        var row = MyDataTable.NewRow();
        row["Date"] = date;
        row["Caller"] = caller;
        row["Result"] = result;
        MyDataTable.Rows.Add(row);
    }
    protected override void OnClosed(EventArgs e)
    {
        if (_myDataTable != null)
            _myDataTable.WriteXml(_fileName,  XmlWriteMode.WriteSchema);
        base.OnClosed(e);
    }
