        public void SaveAs(string csvPath)
        {
            string data = ExportDataGrid(true, _flexGrid);
            StreamWriter sw = new StreamWriter(csvPath, false, Encoding.UTF8);
            sw.Write(data);
            sw.Close();
        }
        public string ExportDataGrid(bool withHeaders, Microsoft.Windows.Controls.DataGrid grid) 
        {
            System.Text.StringBuilder strBuilder = new System.Text.StringBuilder();
            System.Collections.IEnumerable source = (grid.ItemsSource as System.Collections.IEnumerable);
            if (source == null) return "";
            List<string> headers = new List<string>();
            grid.Columns.ToList().ForEach(col =>
            {
                if (col is Microsoft.Windows.Controls.DataGridBoundColumn)
                {
                    headers.Add(col.Header.ToString());
                }
            });
            strBuilder.Append(String.Join(",", headers.ToArray())).Append("\r\n");
            foreach (Object data in source)
            {
                System.Data.DataRowView d = (System.Data.DataRowView)data;
                strBuilder.Append(String.Join(",", d.Row.ItemArray)).Append("\r\n");
            }
            return strBuilder.ToString();
        }
