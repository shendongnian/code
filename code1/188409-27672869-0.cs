    private void hearingsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                //TODO - Button Clicked - Execute Code Here
               
                string x=myDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                Form1 myform = new Form1();
                myform.rowid= (int)x;
                myform.Show();
            }
        }
