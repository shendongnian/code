        private void TestDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
           {
             if(TestDataGridView.CurrentCell.ColumnIndex.Equals(1))
            {
              e.Control.KeyPress += Control_KeyPress; // Depending on your requirement you can register any key event for this.
            }
         }
    
    private static void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
          // Write your logic to convert the letter to uppercase
        }
