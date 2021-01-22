    function assignExcelSheetToGrid(string theConnString, YOURGRIDTYPE theGrid){
        //Make sure you change YOURGRIDTYPE (Above) to the type of grid you are passing
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
