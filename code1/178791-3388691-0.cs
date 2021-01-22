    public class Person
    {
        protected static Random rnd = new Random();
    }
    public class PersonImpl : Person
    {
        public void DoSomething()
        {
            int a = rnd.Next(100, 9999);
        }
    }
