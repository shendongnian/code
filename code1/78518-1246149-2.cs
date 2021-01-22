    private EventHandler clickHandler; // Normal private field
    public event EventHandler Click
    {
        add
        {
            Console.WriteLine("New subscriber");
            clickHandler += value;
        }
        remove
        {
            Console.WriteLine("Lost a subscriber");
            clickHandler -= value;
        }
    }
