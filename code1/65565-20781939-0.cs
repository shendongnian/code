    for (int i = 0; i < grdSpec.Columns.Count; i++) 
    {
        // The column width adjusts to fit the contents all cells in the control.
        grdSpec.Columns[i].AutoSizeMode = BestFitColumnMode.AllCells; 
    }
