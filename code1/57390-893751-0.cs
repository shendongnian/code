    /* Replace with the path to your Access database */
    string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\mydatabase.mdb;User Id=admin;Password=;";
    
    try
    {
    using(OleDbConnection conn = new OleDbConnection(connectionString)
    {
       conn.Open();       
       string myQuery = "Select * FROM tableName WHERE date='03/02/2009'";       
       OleDbCommand cmd = new OleDbCommand(myQuery, conn);
       using(OleDbDataReader reader = cmd.ExecuteReader())
       {
          //iterate through the reader here
          while(reader.Read())
          {
             //or reader[columnName] for each column name
             Console.WriteLine("Fied1 =" + reader[0]); 
          }
       }
    }
       
    }
    catch (Exception e)
    {
       Console.WriteLine(e.Message);
    }
