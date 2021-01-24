     private void Grid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
                if(e.Column.Header.ToString().Equals("Qty"))
                { 
                     var d = ((Data)e.Row.DataContext).Qty;
                }
        }
    
