                DateTime? myDate;
                //Code to set myDate value...
                string sql = "[your SQL]"
                using (OracleCommand command = new SqlCommand(sql, cn))
                {
                    OracleParameter param = new OracleParameter(":Name",myDate);
                    command.Paerameters.add(param);
                    command.ExecuteNonQuery();
                }
   
