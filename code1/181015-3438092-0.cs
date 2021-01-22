    public class Static<T>
    {
        public static int Number { get; set; }
    }
    static void Main(string[] args)
    {
        Static<int>.Number = 1;
        Static<double>.Number = 2;
        Console.WriteLine(Static<int>.Number + "," Static<double>.Number);
    }
    // Prints 1, 2
