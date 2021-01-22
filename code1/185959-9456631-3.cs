    static void Main(string[] args)
    {
        Person p1 = new Person();
        p1.FirstName = "Joe";
        p1.LastName = "Bloe";
        Console.WriteLine("First = {0} Last = {1}", p.FirstName, p.LastName);
        var p2 = p1.AsReadOnly();
        p2.FirstName = "Josephine"; // AccessViolationException
    }
