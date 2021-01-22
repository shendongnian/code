    static void Main(string[] args)
    {
       Person p = new Person { Name = "HelloWorld" };
       GenericSerializer<Person> ser = new GenericSerializer<Person>();
       ser.Serialize(new StreamWriter("person.xml"), p);
    }
