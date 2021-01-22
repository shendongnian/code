    private void TargetReasonGrid_DragOver(object sender, DragEventArgs e)
    {
        e.Effect = DragDropEffects.Move;
        //Converts window position to user control position (otherwise you can use MousePosition.Y)
        int mousepos = PointToClient(Cursor.Position).Y;
        //If the mouse is hovering over the bottom 5% of the grid
        if (mousepos > (TargetReasonGrid.Location.Y + (TargetReasonGrid.Height * 0.95)))
        {
            //If the first row displayed isn't the last row in the grid
            if (TargetReasonGrid.FirstDisplayedScrollingRowIndex < TargetReasonGrid.RowCount - 1)
            {
                //Increase the first row displayed index by 1 (scroll down 1 row)
                TargetReasonGrid.FirstDisplayedScrollingRowIndex = TargetReasonGrid.FirstDisplayedScrollingRowIndex + 1;
            }
        }
        //If the mouse is hovering over the top 5% of the grid
        if (mousepos < (TargetReasonGrid.Location.Y + (TargetReasonGrid.Height * 0.05)))
        {
            //If the first row displayed isn't the first row in the grid
            if (TargetReasonGrid.FirstDisplayedScrollingRowIndex > 0)
            {
                //Decrease the first row displayed index by 1 (scroll up 1 row)
                TargetReasonGrid.FirstDisplayedScrollingRowIndex = TargetReasonGrid.FirstDisplayedScrollingRowIndex - 1;
            }
        }
    }
