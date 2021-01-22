using (var connection = new OdbcConnection(csb.ConnectionString))
{
    connection.Open();
    using (var command = new OdbcCommand("SELECT * FROM Tabl", connection))
    using (var reader =  command.ExecuteReader())
    {
        for (var count = 0; (count &lt; 5 && reader.Read()); ++count)
        {
            //Read
        }
    }
}
OdbcConnection.ReleaseObjectPool();
