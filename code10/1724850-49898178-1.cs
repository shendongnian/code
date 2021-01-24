    string CellDataID;
    //List<T>(s) are more flexible than arrays
    //new instantiates it
    List<string> IDString = new List<string>;
    for (int RowCount = 2; RowCount <= LastRow; RowCount++)
    {
        xlRange = (Excel.Range)xlSht.Cells[RowCount, colNumberID];
        CellDataID = (string)xlRange.Text;
        PrinterBox1.Items.Add(CellDataID);
        //this is just wrong.
        //IDString = new string[LastRow];
        //add the string to your list
        IDString.Add(CellDataID);  
    }
