       private void reservedGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                var senderGrid = (DataGridView)sender;
        
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                    e.RowIndex >= 0)
                {
    int selectedServiceDetailId=Convert.ToInt(senderGrid.Rows[e.RowIndex].Cells["Service_Detail_ID"].Value));
                    //TODO - Button Clicked - Execute Code Here 
                    ServiceDetail viiew = new ServiceDetail();
                    viiew.SelectedId=selectedServiceDetailId;
                    viiew.Show();
                    }
            }
