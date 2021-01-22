        public static Boolean GetActive(Int32 sessionId)
        {
            Boolean active = false;
            SqlConnectionUniqueInstance.Instance.Open();
            SqlCommand Command = SqlConnectionUniqueInstance.Instance.Connection.CreateCommand();
            Command.CommandText = String.Format(@"SELECT [LogoutDateTime] FROM [dbo].[sessions] WHERE [sessionID] = {0}", sessionId.ToString());
            SqlDataReader DataReader = Command.ExecuteReader();
            while (DataReader.Read())
            {
                System.IO.File.AppendAllText("C:\\Log.txt", "DataBase Time    :" + ((DateTime)DataReader[0]).ToString() + " Kind:" + ((DateTime)DataReader[0]).Kind.ToString() + "\r\n");
                System.IO.File.AppendAllText("C:\\Log.txt", "DateTime.Now Time:" + DateTime.Now.ToString() + " Kind:" + DateTime.Now.Kind.ToString() + "\r\n");
                
                if ((DateTime)DataReader[0] > DateTime.Now)
                    active = true;
                System.IO.File.AppendAllText("C:\\Log.txt", "active:" + active.ToString() + "\r\n");
            }
            DataReader.Close();
            if (active)
                UpdateTime(sessionId);
            Command.Dispose();
            return active;
        }
