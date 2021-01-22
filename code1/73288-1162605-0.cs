    public interface IA
    {
        int a { get; set; }
        void PerformAction();
    }
    
    public class B: IA
    {
        public int a { get; set; }
        public int b { get; set; }
        public void PerformAction()
        {
            // perform action specific to B
        }
    }
    
    public class C : IA
    {
        public int a { get; set; }
        public int c { get; set; }
        public void PerformAction()
        {
            // perform action specific to C
        }
    }
    
    void PerformActionOn(IA instance)
    {
        if (instance == null) throw new ArgumentNullException("instance");
    
        instance.PerformAction();
    
        // Do some other common work...
    }
    
    
    B b = new B();
    C c = new C();
    
    PerformActionOn(b);
    PerformActionOn(c);
