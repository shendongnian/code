            void OneWay()
            {
                System.Data.SqlClient.SqlDataReader reader = null;
                int i = reader.GetInt32(0);
            }
    
            void OtherWay()
            {
                System.Data.SqlClient.SqlDataReader reader = null;
                int i = (int)reader[0];
            }
