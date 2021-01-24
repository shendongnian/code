    public static void FastAutoSizeColumns(this DataGridView targetGrid)
    {
        //If targeted datagridview doesn't have rows just return
        if (targetGrid.Columns.Count < 1)
            return;
        var gridTable = new DataTable();
        // Cast out a DataTable from the target grid datasource.
        // We need to iterate through all the data in the grid and a DataTable supports enumeration.
        gridTable = (DataTable)targetGrid.DataSource;
        targetGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        // Create a graphics object from the target grid. Used for measuring text size.
        using (var gfx = targetGrid.CreateGraphics())
        {
            // Iterate through the columns.
            for (int i = 0; i < gridTable.Columns.Count; i++)
            {
                // Leverage Linq enumerator to rapidly collect all the rows into a string array, making sure to exclude null values.
                string[] colStringCollection = gridTable.AsEnumerable().Where(r => r.Field<object>(i) != null).Select(r => r.Field<object>(i).ToString()).ToArray();
                // Sort the string array by string lengths.
                colStringCollection = colStringCollection.OrderBy((x) => x.Length).ToArray();
                if (colStringCollection.Length > 0)
                {
                    // Get the last and longest string in the array.
                    string longestColString = colStringCollection.Last();
                    // Use the graphics object to measure the string size.
                    var colWidth = gfx.MeasureString(longestColString, targetGrid.Font);
                    // If the calculated width is larger than the column header width, set the new column width.
                    if (colWidth.Width > targetGrid.Columns[i].HeaderCell.Size.Width)
                    {
                        targetGrid.Columns[i].Width = (int)colWidth.Width;
                    }
                    else // Otherwise, set the column width to the header width.
                    {
                        targetGrid.Columns[i].Width = targetGrid.Columns[i].HeaderCell.Size.Width;
                    }
                }
                else
                {
                    targetGrid.Columns[i].Width = targetGrid.Columns[i].HeaderCell.Size.Width;
                }
            }
        }
    }
