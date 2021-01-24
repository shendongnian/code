    static void Main()
    {
        DateTime time = DateTime.Now;             // Use current time.
        string format = "yyyy/MM/dd hh:mm:ss";    // Use this format.
        Console.WriteLine(time.ToString(format)); // Write to console.
    }
