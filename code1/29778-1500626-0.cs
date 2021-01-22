    // here's an example of getting the hex value from a command line 
    // program.exe 0x00080000
    static void Main(string[] args)
    {
        int value = Convert.ToInt32(args[1].Substring(2), 16);
        Console.Out.WriteLine("Value is: " + value.ToString());
    }
