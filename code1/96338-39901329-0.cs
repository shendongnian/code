    private void dgvRiscos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            senderGrid.EndEdit();
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn &&
                e.RowIndex >= 0)
            {
                var cbxCell = (DataGridViewCheckBoxCell)senderGrid.Rows[e.RowIndex].Cells["associado"];
                if ((bool)cbxCell.Value)
                {
                       // Criar registo na base de dados
                }
                else
                {
                       // Remover registo da base de dados
                }
            }
        }
