    public class Outer
    {
        private class Hidden     { public Hidden() {} }
        protected class Shady    { public Shady() {} }
        public class Promiscuous { public Promiscuous() {} }
    }
    public class Sub : Outer
    {
        public Sub():base() 
        {
            var h = new Hidden();      // illegal, will not compile
            var s = new Shady();       // legal
            var p = new Promiscuous(); // legal
        }
    }
    public class Outsider 
    {
        public Outsider() 
        {
            var h = new Outer.Hidden();      // illegal, will not compile
            var s = new Outer.Shady()        // illegal, will not compile
            var p = new Outer.Promiscuous(); // legal
        }
    }
