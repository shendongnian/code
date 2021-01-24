    public class MyDataGridView: DataGridView
    {
        public MyDataGridView()
        {
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ColumnHeadersVisible = false;
            RowHeadersVisible = false;
            MultiSelect = false;
        }
    }
