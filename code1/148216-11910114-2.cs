     using (OleDbConnection conn = new OleDbConnection(connString))
     {
           conn.Open();
           OleDbCommand cmd = conn.CreateCommand();
           for (int i = 0; i < Customers.Count; i++)
           {
                cmd.Parameters.Add(new OleDbParameter("@var1", Customer[i].Name))
                cmd.Parameters.Add(new OleDbParameter("@var2", Customer[i].PhoneNum))
                cmd.Parameters.Add(new OleDbParameter("@var3", Customer[i].ID))
                cmd.Parameters.Add(new OleDbParameter("@var4", Customer[i].Name))
                cmd.Parameters.Add(new OleDbParameter("@var5", Customer[i].PhoneNum))
                cmd.CommandText = "UPDATE Customers SET Name=@var1, Phone=@var2" + 
                                  "WHERE ID=@var3 AND (Name<>@var4 OR Phone<>@var5)";
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
           }
     }
