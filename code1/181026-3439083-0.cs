    private DataTable fruitsDataTable = null;
    private DataView orangesDataView = null;
    private DataView applesDataView = null;
    private void Form1_Load(object sender, EventArgs e)
        {
            fruitsDataTable = new DataTable("Fruits");
            // Dynamically create the DataTable schema for the sake of this example
            fruitsDataTable.Columns.Add("Category", typeof(string));
            fruitsDataTable.Columns.Add("Description", typeof (string));
            fruitsDataTable.Columns.Add("Quantity", typeof(int));
            fruitsDataTable.Columns.Add("Price", typeof(double));
            // Add the fruits to the main table
            fruitsDataTable.Rows.Add("ORANGE", "Fresh Oranges", 5, 5.50);
            fruitsDataTable.Rows.Add("APPLE", "Granny Smith Apples", 10, 2.20);
            fruitsDataTable.Rows.Add("APPLE", "Golden Apples", 40, 1.75);
            fruitsDataTable.Rows.Add("ORANGE", "Bloody Oranges", 10, 7.99);
            fruitsDataTable.Rows.Add("BANANA", "Ivory Coast Bananas", 5, 6.99);
            mainGridView.DataSource = fruitsDataTable;
            // Create a DataView for each fruit category and bind it to the relevant DataGridView control on the form
            orangesDataView = new DataView(fruitsDataTable, "Category = 'ORANGE'", string.Empty, DataViewRowState.CurrentRows);
            orangesGridView.DataSource = orangesDataView;
            applesDataView = new DataView(fruitsDataTable, "Category = 'APPLE'", string.Empty, DataViewRowState.CurrentRows);
            applesGridView.DataSource = applesDataView;
        }
