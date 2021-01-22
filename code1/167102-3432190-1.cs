    static void Main(string[] args)
    {
        var list = new List<Person>(new[] 
        { 
            new Person { FirstName = "John" }, 
            new Person { FirstName = "Jane" }
        }).AsQueryable();
        
        foreach (var o in GetSortedData(list, "FirstName")) 
            Console.WriteLine(o.FirstName);
    }
    public class Person
    {
        public string FirstName { get; set; }
    }
