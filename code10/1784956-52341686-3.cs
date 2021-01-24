    void UpdateEntry()
        {
            string sqlstring = "ConnectionDetails";
            using (var con = new SqlConnection(sqlstring))
            {
                var cmd = con.CreateCommand();
                cmd.Parameters.AddWithValue("@TASID","Your TASID Data Dude");
                cmd.CommandText = "UPDATE Tenements WHERE TAS_ID='@TASID'";
            }
        }
