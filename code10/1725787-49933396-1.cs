    public static void Main(string[] args)
    {
       Console.WriteLine("Enum Count from class : " + GetEnumCountFromClass<Program>());
       Console.WriteLine("Enum Count from assembly : " + GetEnumFromAssembly(Assembly.GetExecutingAssembly()));
    }
