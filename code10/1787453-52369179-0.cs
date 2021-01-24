    public class Demo<A> where A : IEquatable<A>
    {
        public Demo()
        {
           DemoB = new List<A>();
        }
    
        public Demo(A demoA) : this()
        {
            DemoA = demoA;            
        }
    
        public A DemoA { get; }
        public IList<A> DemoB { get; }
    }
