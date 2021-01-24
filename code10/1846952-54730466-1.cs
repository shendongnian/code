    private void dgvTester_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
    {
        try
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid[e.ColumnIndex, e.RowIndex] is DataGridViewButtonCell)
            {
                 // "3" in following `if` condition is the column index of "Status" column.
                 // You need to put appropriate column index here.
                   var selectedStatus = senderGrid[3, e.RowIndex].Value.ToString();
                    if (selectedStatus  == "New")
                    {
                        MessageBox.Show("New");
                    }
                    else if (selectedStatus == "Open")
                    {
                        MessageBox.Show("Open");
                    }
                    else if (selectedStatus == "Assigned")
                    {
                        MessageBox.Show("Assigned");
                    }
                    else if (selectedStatus == "Duplicate")
                    {
                        MessageBox.Show("Duplicate");
                    }
             }
         }
         catch (Exception error)
         {
             MessageBox.Show(error + "Invalid");
         }
     }
