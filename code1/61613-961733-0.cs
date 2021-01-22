    class O
    {
        public int prop = 0;
    }
    class Program
    {
        static void Main(string[] args)
        {
            O o1 = new O();
            o1.prop = 1;
            O o2 = new O();
            o2.prop = 2;
            o1modifier(o1);
            o2modifier(ref o2);
            Console.WriteLine("1 : " + o1.prop.ToString());
            Console.WriteLine("2 : " + o2.prop.ToString());
            Console.ReadLine();
        }
        static void o1modifier(O o)
        {
            o = new O();
            o.prop = 3;
        }
        static void o2modifier(ref O o)
        {
            o = new O();
            o.prop = 4;
        }
    }
