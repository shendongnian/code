    using (var connection = new SqliteConnection("" + new SqliteConnectionStringBuilder
    {
         DataSource = "C:\\temp\\test.db"
    }))
    {
         connection.Open();
         using (var command = connection.CreateCommand())
         {
               command.CommandText = "create table test(field1 varchar(20))";
               command.ExecuteNonQuery();
         }
     }
