    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
             List<a> a = new List<a>();
             List<b> b = new List<b>();
             List<c> c = new List<c>();
             test(a);
             test(b);
             test(c);
    
            }
    
            static void test<T>(List<T> a) where T : a
            {
                return;
            }
        }
        class a
        {
    
        }
        class b : a
        {
    
        }
        class c : b
        {
    
        }
    }
