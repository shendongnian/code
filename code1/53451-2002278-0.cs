    private void dgvRaceDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
                if (e.ColumnIndex == 5)
                {
                    dgvRaceDetails.Rows[e.RowIndex].Cells[5].Value =
                        !(Boolean)dgvRaceDetails.Rows[e.RowIndex].Cells[5].Value;
                }
    
                if (e.ColumnIndex == 6)
                {
                    dgvRaceDetails.Rows[e.RowIndex].Cells[6].Value =
                        !(Boolean)dgvRaceDetails.Rows[e.RowIndex].Cells[6].Value;
                }
    }
