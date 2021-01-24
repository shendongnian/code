    class Program
    {
      static void Main()
      {
        MainAsync().Wait();
      }
      static async Task MainAsync()
      {
        try
        {
          // Asynchronous implementation.
          await Task.Delay(1000);
        }
        catch (Exception ex)
        {
          // Handle exceptions.
        }
      }
    }
