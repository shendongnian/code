    if ((cell.DataType != null) && (cell.DataType == CellValues.SharedString))
    {
        int ssid = int.Parse(cell.CellValue.Text);
        string str = sst.ChildElements[ssid].InnerText;
        Console.WriteLine("Shared string {0}: {1}", ssid, str);
    }
    else if (cell.CellValue != null)
    {
        Console.WriteLine("Cell contents: {0}", cell.CellValue.Text);
    }
