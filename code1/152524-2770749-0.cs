    static class DataGridViewExtender
    {
        public static void ExportToCSV(this DataGridView grid, string path)
        {
            ExportToFile(grid, path, ",");
        }
        public static void ExportToFile(this DataGridView grid, string path, string separator)
        {
            if (grid.Columns.Count <= 0)
            { return; }
            using (var writer = new StreamWriter(path))
            {
                var values = new List<string>(grid.Columns.Count);
                foreach (DataGridViewColumn column in grid.Columns)
                {
                    values.Add(column.Name);
                }
                writer.WriteLine(string.Join(separator, values.ToArray()));
                foreach (DataGridViewRow row in grid.Rows)
                {
                    values.Clear();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        values.Add(string.Format("{0}", cell.Value));
                    }
                    writer.WriteLine(string.Join(separator, values.ToArray()));
                }
                writer.Close();
            }
        }
    }
