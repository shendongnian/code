          //create connection    
            string connString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=c:\Status.mdb";
            OleDbConnection conn = new OleDbConnection(connString);
          //command
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText = "tblOutbox";
            cmd.CommandType = CommandType.TableDirect;           
            conn.Open();
          //write into text file
            StreamWriter tw = File.AppendText("c:\\INMS.txt");
            OleDbDataReader reader = cmd.ExecuteReader();
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
            tw.Close();            
            reader.Close();
            conn.Close();        
</pre>
