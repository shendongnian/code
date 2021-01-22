    // in base UserControl
    public BaseGridDetail()
    {
        InitializeComponent();
        InitGridColumns(dataGridView1.Columns);
    }
    protected virtual void InitGridColumns(DataGridViewColumnCollection columns)
    {
        columns.Clear();
    }
