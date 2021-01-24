class Program
{
    static void Main(string[] args)
    {
        var a = new Test { Name = "First" };
        ref Test b = ref a;
        ref Test c = ref a;
        Console.WriteLine(b.Name); // dereferences b, prints "Hello World!"
        Console.WriteLine(c.Name); // dereferences c, prints "Hello World!"
        b = new Test { Name = "Goodbye :(" }; // change the target of ref b to a new object
        // dereference c again, points to the new object
        // prints "Goodbye :("
        Console.Write(c.Name); 
    }
}
public class Test
{
    public string Name { get; set; }
}
