    private void Grid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
                if(e.Column.Header.ToString().Equals("Qty"))
                { 
                     var NumericDataCtrl= GetVisualChild<NumericTextColumn>(e.EditingElement);
                        var data  = NumericDataCtrl.Text;
                }
        }
