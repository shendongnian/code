    public void Start()
    {
        try
        {
            new Bot().StartAsync(tokenSource.Token).GetAwaiter().GetResult();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
