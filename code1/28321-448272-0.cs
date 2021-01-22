    public class Child : Parent
    {
        private int foo = 10;
        protected override void ShowFoo()
        {
            Console.WriteLine(foo);
        }
    }
