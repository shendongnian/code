        private void DgSQLDataSizeChanged(object sender, SizeChangedEventArgs e)
        {
            var myDataGrid = (DataGrid)sender;
            
            // Do not change column size if Visibility State Changed
            if (myDataGrid.RenderSize.Width == 0) return;
            
            double totalActualWidthOfNonStarColumns = myDataGrid.Columns.Sum(
                c => c.Width.IsStar ? 0 : c.ActualWidth);
            double totalDesiredWidthOfStarColumns = 
                myDataGrid.Columns.Sum(c => c.Width.IsStar ? c.Width.Value : 0);
            if ( totalDesiredWidthOfStarColumns == 0 ) 
                return;  // No star columns
            
            // Space available to fill ( -18 Standard vScrollbar)
            double spaceAvailable = (myDataGrid.RenderSize.Width - 18) - totalActualWidthOfNonStarColumns;
            
            double inIncrementsOf = spaceAvailable/totalDesiredWidthOfStarColumns;
            foreach (var column in myDataGrid.Columns)
            {
                if ( !column.Width.IsStar ) continue;
                var width = inIncrementsOf * column.Width.Value;
                column.Width = new DataGridLength(width, DataGridLengthUnitType.Star);
            }
        }
