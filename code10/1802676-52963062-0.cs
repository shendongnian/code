    // A command requires an sql text and an OPEN connection to execute....
    OleDbCommand cmd = new OleDbCommand(sqlCommand, connection);
    // Use directly the parameters collection inside the command object
    var parameters = cmd.Parameters;
    // Loop over the WIData array length (10 times = 30 parameters)
    for (int i = 0; i < WITestData.WIData.Length; i++)
    {
        // No need to give an unique name, however, if you really want a name 
        //  you can replace ? with 
        // "W"+i.ToString(), "A"+i.ToString() and "C"+i.ToString()
        parameters.Add("?", OleDbType.Decimal).Value = WITestData.WIData[i].Width;
        parameters.Add("?", OleDbType.Decimal).Value = WITestData.WIData[i].Angle;
        parameters.Add("?", OleDbType.Decimal).Value = WITestData.WIData[i].Comment;
    }  
    parameters.Add("?", OleDbType.Integer).Value = WITestData.ReportNumber;
