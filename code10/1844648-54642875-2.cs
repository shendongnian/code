        private void SetNewUploadFileForGrantAppID(int pIntRecordKeyValue, int pIntCheckBoxStatus)
        {
            SqlConnection connection = new SqlConnection(cs.DBcon);
            try
            {
                SqlCommand sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = "dbo.usp_SetRecordCheckStatus";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@pIntRecordKeyValue", pIntRecordKeyValue);
                sqlCommand.Parameters.AddWithValue("@pIntCheckBoxStatus", pIntCheckBoxStatus);
                connection.Open();
                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                //LogError(ex);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
