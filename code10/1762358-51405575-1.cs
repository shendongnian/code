            using (var command = new OracleCommand(
                                            "SELECT sms_status,sms_opt_in_date FROM member WHERE member_nbr = :memberNumber", connection))
            {
                command.Parameters.Add(
                                        new OracleParameter(
                                        "memberNumber",
                                        OracleDbType.Varchar2,
                                        memberNumber,
                                        ParameterDirection.Input));
            }        
         
                SmsStatus data;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        data = new SmsStatus();
                        data.status = reader["sms_status"].ToString();
                        data.OptInDate = reader["sms_opt_in_date"].ToString();
                        //add data to an array if there is multi rows in result
                        //or break if there is only one line
                        break;
                    }
                }
                return data;
