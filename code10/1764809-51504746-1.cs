    public class A
    {
        public int DoSomething()
        {
            return 42;
        }
    
        public void MakeStuff()
        {
            int x = this.DoSomething();
            // We called the method DoSomething, which returns 42, and now x equals 42.
        }
    }
