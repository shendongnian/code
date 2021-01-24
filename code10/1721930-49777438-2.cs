    string sqlText = "SELECT {{columnName}} FROM Test_Attachments WHERE Project_Id =@PID1 AND [Directory] = @Directory";
    var allowedColumns = new List<string>{"columnA", "columnB"};
    if(allowedColumns.Contains(Employee_Column)
    {
       sqlText = sqlText.Replace("{{columnName}}", Employee_Column);
    } 
    else
    {
       throw new Exception($"Invalid Column {Employee_Column}");
    }
    try {
        SqlCommand myCommand = new SqlCommand(sqlText, SqlConnection);
        var directory = qAttachment.Directory1.Replace("\\\\" + Root_Directory, "");
         myCommand.Parameters.AddWithValue("@PID1", Project_ID1);
         myCommand.Parameters.AddwithValue("@Directory", directory);
         ...
    }
