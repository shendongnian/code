    private void dgvTester_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
    {
        try
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid[e.ColumnIndex, e.RowIndex] is DataGridViewButtonCell)
            {
                 // "3" in following `if` condition is the column index of "Status" column.
                 // You need to put appropriate column index here.
                 if(senderGrid[3, e.RowIndex].Value.ToString()  == "New")
                 {
                    //Replace all the "MessageBox.Show" here with your own code of showing some other form.
                    MessageBox.Show("New");
                 }
                 else if (senderGrid[3, e.RowIndex].Value.ToString() == "Open")
                 {
                    MessageBox.Show("Open");
                 }
                 else if (senderGrid[3, e.RowIndex].Value.ToString() == "Assigned")
                 {
                     MessageBox.Show("Assigned");
                 }
                 else if (senderGrid[3, e.RowIndex].Value.ToString() == "Duplicate")
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
