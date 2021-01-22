    public static void Main(string[] args)
    {
        Thread thread = new Thread(Work);
       
        thread.Start("I've got some text");
        Console.ReadLine();
    }
    private static void Work(object data)
    {
        string message = (string)data; // Wow, this is ugly
        Console.WriteLine($"I, the thread write: {message}");
    }
