       private void reservedGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                var senderGrid = (DataGridView)sender;
        
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                    e.RowIndex >= 0)
                {
    int selectedId=Convert.ToInt(senderGrid.Rows[e.RowIndex].Cells["Service_Detail_ID"].Value));
                    //TODO - Button Clicked - Execute Code Here 
                    ServiceDetail viiew = new ServiceDetail(selectedId);
                    //viiew.ref_branch1 = this;
                    viiew.Show();
                    }
            }
