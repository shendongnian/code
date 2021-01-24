    private Task<int> TestAsync()
    {
        return Task.Run(() =>
        {
            for (int i = 0; i < 20000; i++)
                ;
            Console.WriteLine("Logic C");
            return Task.FromResult(0);
        });
    }
