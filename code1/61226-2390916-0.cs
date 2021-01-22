    public class Gallons
    {
        private int m_gallons;
        public Gallons(int count)
        {
            if(count < 0)
                throw new ArgumentException("Cannot have negative gallons");
            m_gallons = count;
        }
        static public Gallons operator + (Gallons left, Gallons right)
        {
            return new Gallons(left.m_gallons + right.m_gallons);
        }
        public override string ToString()
        {
            return m_gallons.ToString();
        }
    }
    public class Feet
    {
        private int m_feet;
        public Feet(int count)
        {
            if(count < 0)
                throw new ArgumentException("Cannot have negative feet");
            m_feet = count;
        }
        static public Feet operator +(Feet left, Feet right)
        {
            return new Feet(left.m_feet + right.m_feet);
        }
        public override string ToString()
        {
            return m_feet.ToString();
        }
    }
    public static class Conversions
    {
        static public Feet Feet(this int i)
        {
            return new Feet(i);
        }
        static public Gallons Gallons(this int i)
        {
            return new Gallons(i);
        }
    }
    public class Test
    {
        static public int Main(string[] args)
        {
            System.Console.WriteLine(2.Feet() + 3.Feet()); // 5
            System.Console.WriteLine(3.Gallons() + 4.Gallons()); // 7
            System.Console.WriteLine(2.Feet() + 3.Gallons()); // doesn't compile - can't add feet to gallons!
            return 0;
        }
    }
