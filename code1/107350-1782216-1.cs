    static void ProcessPerson(Person p)
    {
        Console.WriteLine("Id :{0},Name :{1}", p.Id, p.Name);
    }
    // C# 2
    static void Main()
    {
        Person p = new Person();
        p.Id = "cs0001";
        p.Name = "William";
        Thread th = new Thread(delegate() { ProcessPerson(p); });
        th.Start();
    }
    // C# 3
    static void Main()
    {
        Person p = new Person();
        p.Id = "cs0001";
        p.Name = "William";
        Thread th = new Thread(() => ProcessPerson(p));
        th.Start();
    }
