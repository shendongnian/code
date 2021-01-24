        private void Populate()
        {
            DataTable dataTable = new DataTable("SchdeuleTicketUpdates");
            //we create column names as per the type in DB 
            dataTable.Columns.Add("ScheduledStartUTC", typeof(DateTime));
            dataTable.Columns.Add("ScheduleId", typeof(Int32));
            dataTable.Columns.Add("PatchSessionId", typeof(Int32));
            //write you loop to populate here
            //call the stored proc
            using (var conn = new SqlConnection(connString))
            {
                var command = new SqlCommand("[usp_UpdateTickets]");
                command.CommandType = CommandType.StoredProcedure;
                var parameter = new SqlParameter();
                //The parameter for the SP must be of SqlDbType.Structured 
                parameter.ParameterName = "@ScheduleUpdates";
                parameter.SqlDbType = System.Data.SqlDbType.Structured;
                parameter.Value = dataTable;
                command.Parameters.Add(parameter);
                command.ExecuteNonQuery();
            }
        }
