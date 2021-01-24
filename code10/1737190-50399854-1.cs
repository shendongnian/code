    public class MyBase
    {
        protected string Secret = "hello123";
    }
    public class MyDerived : MyBase
    {
        public void DoSomething()
        {
            Console.WriteLine(Secret);  // Will write the secret variable value
        }
    }
