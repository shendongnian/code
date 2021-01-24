    public static void Main(string[] args)
    {
        A test = new B();
    
        Console.WriteLine(test.s); // A
    
        B test2 = test as B;
    
        Console.WriteLine(test2.s); // B
    }
    
    public class A 
    {
        public string s = "A";
    }
    
    public class B : A
    {
        public new string s = "B";
    }
