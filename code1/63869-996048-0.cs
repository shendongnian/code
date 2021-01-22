    public class Banana : Fruit
    {
        static Banana()
        {
            Suppliers.Add("Company B");
        }
        public static void Foo()
        {
            
        }
    }
    // ...
    Banana.Foo();
    foreach (var supplier in Banana.Suppliers)
        Console.WriteLine(supplier);
