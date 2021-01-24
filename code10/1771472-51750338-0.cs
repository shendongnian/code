    var colValues;
    if (mergeCells.Columns[1].Cells.Count > 1)
    {
        colValues = (System.Array)mergeCells.Columns[1].Cells.Value;
    }
    else
    {
        // NB: you may need to cast other data types to string
        //     or you could use .Cells[0].Text.Split()
        colValues = (System.Array)mergeCells.Columns[1].Cells[0].Value.Split();
    }
