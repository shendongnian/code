    public class ExampleClass
    {
        public static void StaticFunction()
        {
            Console.WriteLine("You can call me from my class-name");
        }
        public void Method()
        {
            Console.WriteLine("I'm called on an object.");
        }
    }
    public static void Main(string[] args)program..
    {
        ExampleClass.StaticFunction();
        ExampleClass exampleObject = new ExampleClass();
        exampleObject.Method();
    }
