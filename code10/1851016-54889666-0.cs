    public async Task FooAsync()
    {
        Console.WriteLine("Before");
        await Task.Delay(1000);
        Console.WriteLine("After");
    }
