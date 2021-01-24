    static async Task RunSomeCommand(string connString)
    {
        try
        {
            using (var connection = new SqlConnection(connString))
            {
                var cmd=new SqlCommand(...);
                await connection.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
            }
        }
        catch (Exception ex)
        {
              console.writeLine("exception");
        }
    }   
    static async Task RunManyCommands()
    {
       var listOfConnections=new List<string>();
       //Somehow load all connection strings
       var tasks = from cn in listOfConnections
                   select RunSomeCommand(cn);
       await Task.WhenAll(tasks);
    }
    class Program
    {
       static async Task Main(string[] args)
       {
          Console.WriteLine("Starting");
          await RunManyCommands();
          Console.WriteLine("Finished");
       }
    }
