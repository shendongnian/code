    public class Foo
    {
        int x = 10;
    
        public void SomeMethod()
        {
            Console.WriteLine(x);
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Hello");
                Thread.Sleep(100);
            }
        }
    }
