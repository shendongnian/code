    public void CheckForReports()
    {
        {
            SqlConnection sqlConnection;
            sqlConnection = new SqlConnection("Server=****;Database=ChrisCMS; Trusted_Connection=True;");
            sqlConnection.Open();
            using (sqlConnection)
            {
                SqlCommand command = new SqlCommand(
                    "Select * from SentReports;");
                ***command.Connection = sqlConnection;***
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    DataClasses1DataContext classes1DataContext = new DataClasses1DataContext();
                    foreach (SentReport entity in classes1DataContext.SentReports)
                    {
                        new ReportSender.MyReportRenderer().RenderTest(entity.QueueReports);
                        classes1DataContext.SentReports.DeleteOnSubmit(entity);
                    }
                    classes1DataContext.ExecuteCommand("TRUNCATE TABLE SentReports");
                    classes1DataContext.SubmitChanges();
                }
                reader.Close();
            }
        }
    }
