        [WebMethod]
        public byte[] Image(string c, string r)
        {
           //check input ..
            ConnectionDatabase connbaseloc = new ConnectionDatabase();
            AseConnection conn1 = null;
            AseCommand cmd1 = null;
            string sqlstr1 = "";
            AseDataReader reader = null;
            byte[] Imagebytes = null;
            try
            {
                using (conn1 = connbaseloc.Odbcconn_xxx())
                {
                    string setTextCmd = " SET TEXTSIZE 130000"; //set parameter
                    cmd1 = new AseCommand(setTextCmd, conn1);
                    cmd1.ExecuteNonQuery();
                    sqlstr1 = "select ....";
                    cmd1 = new AseCommand(sqlstr1, conn1);
                    cmd1.CommandText = sqlstr1;
                    reader = cmd1.ExecuteReader();
                    while (reader.Read())
                    {
                        Imagebytes = (byte[])reader["Image"];
                    }
                }
            }
            catch (Exception e)
            {
                //do something
            }
            finally
            {
                if (conn1 != null) conn1.Close();
            }
            return Imagebytes;
        }
