    class MyClass<Type1>
    {
        public Type data;
    }
    static void Main()
    {
        Console.WriteLine(typeof(MyClass<>).GetGenericArguments()[0].Name);
        //prints: Type1
    }
