    namespace GenericSO
    {
        public class Class1
        {
            public int property1 { get;set;}
    
        }
    
        public class Class2<T>
        {
            public T property2 { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Class1 c1 = new Class1();
                c1.property1 = 20;
    
                Class2<int> c2 = new Class2<int>();
    
                c2.property2 = c1.property1;
            }
        }
    }
