    public YourViewModel()
    {
        YourCommand = new Command(() =>
        {
            Console.WriteLine("TADA!");
        });
    }
