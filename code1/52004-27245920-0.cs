        if (e.Row.RowType == DataControlRowType.Footer)
        {
           e.Row.Cells.RemoveAt(1);
           e.Row.Cells[0].ColumnSpan = 2;
        }
        
    }
