    class Foo
    {
        public Foo(string name) {
            ...
        }
    
        public Foo(Bar bar): base(GetName(bar)) {
            ...
        }
        static string GetName(Bar bar) {
            if(bar == null) {
                // or whatever you want ...
                throw new ArgumentNullException("bar");
            }
            return bar.Name;
        } 
    }
