    static void Main()
    {
        Person p = new Person();
        p.Id = "cs0001";
        p.Name = "William";
        Thread th = new Thread(new ParameterizedThreadStart(ProcessPerson));
        th.Start(p);
    }
    static void ProcessPerson(object o)
    {
        Person p = (Person) o;
        Console.WriteLine("Id :{0},Name :{1}", p.Id, p.Name);
    }
