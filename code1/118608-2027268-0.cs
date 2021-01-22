    public class Foo
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    [WebMethod]
    public string HelloWorld(Foo foo)
    {
        return "Hello World";
    }
