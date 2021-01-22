    public void method()
    {
        Console.WriteLine(this.name);
    }
    static void Main(string[] args)
    {
        Person p = new Person("James"); // Current Object
        p.method();
        Person p2 = new Person("Peter");  // Current Object
        p2.method();
        Person p3 = new Person("Frank");  // Current Object
        p3.method();
        Console.ReadLine();
    }
