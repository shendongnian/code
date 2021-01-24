    var cell = row.Elements<Cell>().FirstOrDefault();
    string cellValue = null;
    if (cell.DataType != null && cell.DataType == CellValues.SharedString)
    {
        //it's a shared string so use the cell inner text as the index into the 
        //shared strings table
        var stringId = Convert.ToInt32(cell.InnerText);
        cellValue = workbookPart.SharedStringTablePart.SharedStringTable
            .Elements<SharedStringItem>().ElementAt(stringId).InnerText;
    }
    else
    {
        //it's NOT a shared string, use the value directly
        cellValue = cell.InnerText;
    }
