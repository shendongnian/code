    using(StreamWriter tw = File.AppendText("c:\INMS.txt"))
    {
        using(SqlDataReader reader = cmd.ExecuteReader())
        {
          tw.WriteLine("id, ip_add, message, datetime");
          while (reader.Read())
          {
             tw.Write(reader["id"].ToString());
             tw.Write(", " + reader["ip_add"].ToString());
             tw.Write(", " + reader["message"].ToString());
             tw.WriteLine(", " + reader["datetime"].ToString());
          }
          tw.WriteLine(DateTime.Now);
          tw.WriteLine("---------------------------------");
       }
    }
