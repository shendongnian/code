      private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (dataGridView1[e.ColumnIndex, e.RowIndex].GetContentBounds(e.RowIndex).Contains(e.Location))
                {
                    cellEndEditTimer.Start();
                }
            }
            
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        { /*place your code here*/}
        private void cellEndEditTimer_Tick(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            cellEndEditTimer.Stop();
        }
