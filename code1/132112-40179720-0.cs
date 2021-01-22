    class Program
    {
        static void Main(string[] args)
        {
            I i = new I();
            int res = i.m1();
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
    public class E
    {
        new public int x = 3;
    }
    public class F:E
    {
        new public int x = 5;
    }
    public class G:F
    {
        new public int x = 50;
    }
    public class H:G
    {
        
        new public int x = 20;
    }
    public class I:H
    {
       new public int x = 30;
        public int m1()
        {
           //   (this as <classname >) will use for accessing data to base class
            int z = (this as I).x + base.x + (this as G).x + (this as F).x + (this as E).x;   // base.x refer to H
            return z;
        }
    }
}
