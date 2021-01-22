            try
            {
                DataTable resultTable = DBUtility.GetSingleDBTableResult(connectionString, "SELECT * FROM MyDBTable");
                List<string> resultsList = new List<string>();
                foreach (DataRow dataRow in resultTable.Rows)
                {
                    resultsList.Add(dataRow[0].ToString());
                }
                return resultsList; 
            }
            finally
            {
                resultTable.Dispose();
            }
