      delegate void del_(int no1,int no2);
    class Math
    {
       public static void add(int x,int y)
       {
         Console.WriteLine(x+y);
       }
       public static void sub(int x,int y)
       {
         Console.WriteLine(x-y);
       }
    }
    
        
    
        class Program
        {
            static void Main(string[] args)
            {
                del_ d1 = new del_(Math.add);
                d1(10, 20);
                del_ d2 = new del_(Math.sub);
                d2(20, 10);
                Console.ReadKey();
            }
        }
