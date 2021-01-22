    public class Foo
    {
        private readonly object padlock = new object();
        public void SomeMethod()
        {
            lock(padlock)
            {
                ...
            }
        }
    }
