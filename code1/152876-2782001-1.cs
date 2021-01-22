        using (Adomd.AdomdConnection adomdConnection = new Microsoft.AnalysisServices.AdomdClient.AdomdConnection())
        {
            adomdConnection.ConnectionString = cubeConnectionString;
            Adomd.AdomdCommand adomdCommand = new Microsoft.AnalysisServices.AdomdClient.AdomdCommand();
            adomdCommand.Connection = adomdConnection;
            adomdCommand.CommandText = mdxQuery;
            adomdConnection.Open();
            cellSet = adomdCommand.ExecuteCellSet();
            adomdConnection.Close();
        }
