       void SaveDataGridViewToCSV(string filename)
        {
            var sb = new StringBuilder();
            
            //SOLUTION disable AllowUserInput to avoid empty set saved to CSV
            dataGridView1.AllowUserToAddRows = false;
            var headers = dataGridView1.Columns.Cast<DataGridViewColumn>();
            sb.AppendLine(string.Join(";", headers.Select(column => "" + column.HeaderText + ";").ToArray()));
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var cells = row.Cells.Cast<DataGridViewCell>();
                sb.AppendLine(string.Join(";", cells.Select(cell => "" + cell.Value + ";").ToArray()));
            }
            try
            {
                File.WriteAllText(filename, sb.ToString());
            }
            catch (Exception exceptionObject)
            {
                MessageBox.Show(exceptionObject.ToString());
            }
        }
