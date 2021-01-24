    static void Main(string[] args)
    {
        ServiceClient client = new ServiceClient();
        try
        {
            var result = client.AddInt(23, 55);
            Console.WriteLine(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
