    public class Foo
    {
        private readonly padlock = new object();
        public void SomeMethod()
        {
            lock(padlock)
            {
                ...
            }
        }
    }
