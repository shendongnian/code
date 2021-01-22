class Program 
{
    SQLiteConnection sourceConnection;
    SQLiteConnection destinationConnection;
    static void Main(string[] args)
    {
        Program shell = new Program();
        // get connection strings from command line arguments
        string sourceConnectionString = shell.getConnectionString(args);
        string destinationConnectionString = shell.getConnectionString(args);
        using (sourceConnection = new SQLiteConnection(sourceConnectionString))
        using (destinationConnection = new SQLiteConnection(destinationConnectionString))
        {
            shell.doDatabaseWork();
        }
    }
    private void doDatabaseWork()
    {
        // use the connections here
    }
}
