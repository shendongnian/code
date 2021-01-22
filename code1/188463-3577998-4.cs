    function assignExcelSheetToGrid(string thePath, YOURGRIDTYPE theGrid, int LineCards){
        ///This replaces LoadGrid function
        //Make sure you change YOURGRIDTYPE (Above) to the type of grid you are passing
        String theConnString= "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + thePath + ";Extended Properties=Excel 8.0;";
        OleDbConnection objConn = new OleDbConnection(theConnString);
        objConn.Open();
        OleDbCommand objCmdSelect = new OleDbCommand("SELECT * FROM [LineCards$]", objConn);
        OleDbDataAdapter objAdapter1 = new OleDbDataAdapter();
        objAdapter1.SelectCommand = objCmdSelect;
        DataSet objDataset1 = new DataSet();
        objAdapter1.Fill(objDataset1, "XLData");
        theGrid.DataSource = objDataset1.Tables[0].DefaultView;
        theGrid.PageIndex = LineCards;
        theGrid.DataBind();
        objConn.Close();
    }
