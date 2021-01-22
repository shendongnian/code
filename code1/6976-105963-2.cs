    static void Main(string[] args)
    {
        object val = 'O';
        Console.WriteLine(EnumEqual(TransactionStatus.Open, val));
        val = 'R';
        Console.WriteLine(EnumEqual(DirectionStatus.Left, val));
        Console.ReadLine();
    }
    public static bool EnumEqual(Enum e, object boxedValue)
    {                        
        return e.Equals(Enum.ToObject(e.GetType(), (char)boxedValue));
    }
    public enum TransactionStatus { Open = 'O', Closed = 'C' };
    public enum DirectionStatus { Left = 'L', Right = 'R' };
