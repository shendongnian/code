    public MyDataGridView()
        : base()
    {
        RowStateChanged += MyDataGridView_RowStateChanged;
    }
    void MyDataGridView_RowStateChanged( object sender,
             DataGridViewRowStateChangedEventArgs e )
    {
    }
