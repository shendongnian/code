    static Predicate<int> Test()
    {
        Predicate<int> test = delegate(int i) { return false; };
        return test;
    }
    static void Main()
    {
        Predicate<int> test1 = Test();
        Predicate<int> test2 = Test();
        Console.WriteLine(test1.Equals( test2 )); // True
        test1 = delegate(int i) { return false; };
        test2 = delegate(int i) { return false; };
        Console.WriteLine(test1.Equals( test2 )); // False
    }
