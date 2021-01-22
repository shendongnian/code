    private DataTable dataTable;
    public Constructor()
    {
        ....
        this.dataTable = new DataTable();
        dataGridView.DataContext = dataTable;
        ....
    }
