    public class BaseClass
      {
        public int x { get; set; }
      }
    
    public class A : BaseClass
    {
        public A() { x = 5; }
    }
    public class B : BaseClass {
        public int y { get; set; }
        public B()
            {
                x = 5; y = 5;
            }
        }
    class Program
    {
            static void Main(string[] args)
        {
            BaseClass bClase = new BaseClass();
            A a = bClase as A; //a = null
            B b = bClase as B; // c = null
            
            BaseClass bClase2 = new A();
            A a2 = bClase2 as A; //works fine
            B b2 = bClase2 as B; // b2 = null
            BaseClass bClase3 = new B();
            A a3 = bClase3 as A; // b2 = null
            B b3 = bClase3 as B; //works fine
            //Cast down = ok
            BaseClass bb = bClase3 as BaseClass;
        }
    }
