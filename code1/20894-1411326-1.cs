            if (gridColumns.Count > 0)
                myGrid.Columns.Clear();
            foreach (DataGridColumn c in gridColumns)
            {
                myGrid.Columns.Add(c);
            }
        }
