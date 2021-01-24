     private const int InterestingColumnNumber = 5;
     private const string InterestingColumnToolTipText = "This Space For Rent";
     private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
     {
         var senderGridView = sender as DataGridView;
         if (senderGridView != null)
         {
             if (e.ColumnIndex == InterestingColumnNumber) 
             {
                 var cell = senderGridView.Rows[e.RowIndex].Cells[InterestingColumnNumber];
                 cell.ToolTipText = InterestingColumnToolTipText;
             }
         }
     }
