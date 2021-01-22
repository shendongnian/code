    public enum Turtle
    {
        None = 0,
        Pink,
        Green,
        Blue,
        Black,
        Yellow
    }
    [Flags]
    public enum WriteAccess : short
    {
       None = 0,
       Read = 1,
       Write = 2,
       ReadWrite = 3
    }
    static void Main(string[] args)
    {
        WriteAccess access = WriteAccess.ReadWrite;
        Turtle turtle = access.ChangeType<Turtle>();
    }
