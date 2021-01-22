            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                DataTable dt = new DataTable();
                dt.Columns.Add("Col1");
                dt.Columns.Add("Col2");
                string[] row = { "Col1Value", "Col2Value" };
                dt.Rows.Add(row);
                    bulkCopy.DestinationTableName = "TBL_NAME_GOES_HERE"; //TBL_NAME
                    try
                    {
                        // Write from the source to the destination.
                        bulkCopy.WriteToServer(dt);
                    }
                    catch (SqlException ex)
                    {
                      // Handle Exception
    
                    }
                }
         }
