    {
        DataTable resultTable = DBUtility.GetSingleDBTableResult(connectionString, "SELECT * FROM MyDBTable")'
        try {
            List<string> resultsList = new List<string>();
            foreach (DataRow dataRow in resultTable.Rows) {
               resultsList.Add(dataRow[0].ToString());
            }
            return resultsList;
        }
        finally {
            if (resultTable != null) ((IDisposable)resultTable).Dispose();
        }
    }
