        private void btnUp_Click(object sender, EventArgs e)
        {
            var row = dgvExportLocations.SelectedRows[0];
            if (row != null && row.Index > 0)
            {
                var swapRow = dgvExportLocations.Rows[row.Index - 1];
                object[] values = new object[swapRow.Cells.Count];
                foreach (DataGridViewCell cell in swapRow.Cells)
                {
                    values[cell.ColumnIndex] = cell.Value;
                    cell.Value = row.Cells[cell.ColumnIndex].Value;
                }
                foreach (DataGridViewCell cell in row.Cells)
                    cell.Value = values[cell.ColumnIndex];
                dgvExportLocations.Rows[row.Index - 1].Selected = true;//have the selection follow the moving cell
            }
        }
