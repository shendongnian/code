    public form1()
    {
        InitializeComponent();
        this.dataGridView1.CellMouseEnter += (s, e) => 
            { if (e.ColumnIndex == ImageColumn) dataGridView1.Cursor = Cursors.Hand; };
        this.dataGridView1.CellMouseLeave += (s, e) => 
            { if (e.ColumnIndex == ImageColumn) dataGridView1.Cursor = Cursors.Default; };
    }
