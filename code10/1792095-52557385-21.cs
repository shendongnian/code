    class P
    {
        public static C operator ==(P p1, P p2)
        {
            System.Console.WriteLine("P ==");
            return new C();
        }
        public static C operator !=(P p1, P p2)
        {
            System.Console.WriteLine("P !=");
            return new C();
        }
    }
