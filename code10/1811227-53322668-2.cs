    private void btnSave_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
        
            var headers = dgvCsv1.Columns.Cast<DataGridViewColumn>();
            sb.AppendLine(string.Join(",", headers.Select(column => "\"" + column.HeaderText + "\"").ToArray()));
        
            foreach (DataGridViewRow row in dgvCsv1.Rows)
            {
                var cells = row.Cells.Cast<DataGridViewCell>();
                sb.AppendLine(string.Join(",", cells.Select(cell => "\"" + cell.Value + "\"").ToArray()));
            }
            textBoxExport.Text = sb.ToString();
    
            System.IO.File.WriteAllText(lblFilePath.Text, textBoxExport.Text);
        }
