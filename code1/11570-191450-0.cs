    public class A : B
    {
    
    }
    
    public class B : C
    {
        public int BProperty { get; set; }
    }
    
    public class C
    {
        public int CProperty { get; set; }
    }
    
    public class Test
    {
        public void TestStuff()
        {
            A a = new A();
    
            // These are valid.
            a.CProperty = 1;
            a.BProperty = 2;
        }
    
    }
