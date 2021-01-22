    String reportQuery = @"  complicated query returning many rows    ";
    SqlConnection ReportConnect = new SqlConnection(ConnectionString);
    ReportConnect.Open();
    SqlCommand command = new SqlCommand(reportQuery, ReportConnect);
    command.CommandTimeout = 300; //5 mins
    DataSet tempDataset = new DataSet();
    SqlDataAdapter da = new SqlDataAdapter(command);
    da.Fill(tempDataset);
