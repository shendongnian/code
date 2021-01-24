    public class CustomDataGrid : DataGrid
    {
        public CustomDataGrid()
        {
            Columns.Add(new DataGridTextColumn() { Binding = new Binding("Name"), Header = "Element Name" });
        }
    }
