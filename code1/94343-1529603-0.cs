    String reportQuery = @"  complicated query returning many rows    ";
    SqlConnection ReportConnect = new SqlConnection(ConnectionString);
    ReportConnect.Open();
    SqlCommand command = new SqlCommand(reportQuery, ReportConnect);
    DataSet tempDataset = new DataSet();
    SqlDataAdapter da = new SqlDataAdapter(command);
    da.Fill(tempDataset);
