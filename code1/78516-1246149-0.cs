    private EventHandler clickHandler; // Normal private field
    public EventHandler Click
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
