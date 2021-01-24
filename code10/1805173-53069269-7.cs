    public void Start()
    {
        try
        {
            new Bot().StartAsync(tokenSource.Token).GetAwaiter();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
