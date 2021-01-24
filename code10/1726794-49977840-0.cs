    using (var connection = new SqlConnection())
    {
        using (var command = connection.CreateCommand())
        {
            command.CommandText = "UPDATE " + clsUtility.GetMasterTable() + " SET RECONCILIATION_LAST_UPDATED = @last_updated, CHANGE_DELIVERY_NOTE = @delivery_note";
            var parameterLastUpdated = command.CreateParameter();
            
            parameterLastUpdated.ParameterName = "@last_updated";
            parameterLastUpdated.SqlDbType = SqlDbType.DateTime;
            parameterLastUpdated.Direction = ParameterDirection.Input;
            parameterLastUpdated.Value = DateTime.Today;
            command.Parameters.Add(parameterLastUpdated);
            var parameterDelivery = command.CreateParameter();
            parameterDelivery.ParameterName = "@delivery_note";
            parameterDelivery.SqlDbType = SqlDbType.NVarChar;
            parameterDelivery.Direction = ParameterDirection.Input;
            parameterDelivery.Value = "Some string you want in notes";
            command.Parameters.Add(parameterDelivery);
            command.ExecuteNonQuery();
        }
    }
