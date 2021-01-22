    class Program
    {
        static void Main(string[] args)
        {
            var b = new B();
            b.Method2();
            Console.ReadLine();
        }
    }
    class A 
    { 
 
        public virtual void Method1()
        {
             Console.WriteLine("Method1 in class A");
        } 
     
        public void Method2() 
        { 
             Method1(); 
        } 
    }
    class B : A 
    { 
        public override void Method1() 
        { 
             Console.WriteLine("Method1 in class B"); 
        } 
    } 
 
