using (StreamWriter tw = File.AppendText("c:\\INMS.txt"))
  {
      using (SqlDataReader reader = cmd.ExecuteReader())
      {
          tw.WriteLine("id, ip address, message, datetime");
          while (reader.Read())
          {
              tw.Write(reader["id"].ToString());
              tw.Write(", " + reader["ip"].ToString());
              tw.Write(", " + reader["msg"].ToString());
              tw.WriteLine(", " + reader["date"].ToString());
          }
          tw.WriteLine("Report Generate at : " + DateTime.Now);
          tw.WriteLine("---------------------------------");
          tw.Close();
          reader.Close();
      }
  }</pre>
