    private void dataGridView1_CellClick(object sender,
        DataGridViewCellEventArgs e)
    {
    
        if (turn.Text.Equals(gameOverString)) { return; }
    
        DataGridViewImageCell cell = (DataGridViewImageCell)
            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
    
        if (cell.Value == Play)
        {
            // PlaySomething()
        }
        else if (cell.Value == Sing)
        {
            // SingSomeThing();
        }
        else 
        {
         MessagBox.Show("Please Choose Another Value");
        }
    }
