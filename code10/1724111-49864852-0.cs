    private void yourGridView_SelectionChanged(object sender, EventArgs e)
     {
    //makes sure a row is selected
         if (yourGridView.SelectedCells.Count > 0)
         {
             int selectedrowindex = yourGridView.SelectedCells[0].RowIndex;
             DataGridViewRow selectedRow = yourGridView.Rows[selectedrowindex];  
    //guessing you´re storing your value in a variable
              string a = Convert.ToString(selectedRow.Cells["columnName"].Value);   
    //where columnName is the name of the column you want the value printed of...        
         }
     }
