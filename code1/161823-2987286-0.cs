    class Program
    {
        static void Main(string[] args)
        {
            var g = new GlorifiedInt(7);
            g.Bits[0] = 0;
            Console.WriteLine("g is " + g.Value); // prints "6"
            for (int i = 3; i >= 0; i--)
                Console.Write(g.Bits[i]); // prints "0110"
            Console.WriteLine();
        }
    }
    class GlorifiedInt
    {
        private int m_val;
        public GlorifiedInt(int value)
        {
            m_val = value;
        }
        public int Value
        {
            get { return m_val; }
        }
        public BitAccessor Bits
        {
            get { return new BitAccessor(this); }
        }
        public class BitAccessor
        {
            private GlorifiedInt gi;
            public BitAccessor(GlorifiedInt glorified)
            {
                gi = glorified;
            }
            public int this[int index]
	        {
                get 
                {
                    if (index < 0 || index > 31)
                        throw new IndexOutOfRangeException("BitAcessor");
                    return 1 & (gi.m_val >> index); 
                }
		        set 
                {
                    if (index < 0 || index > 31)
                        throw new IndexOutOfRangeException("BitAcessor");
                    if (value == 1)
                        gi.m_val |= 1 << index;
                    else if (value == 0)
                        gi.m_val &= ~(1 << index);
                    else
                        throw new ArgumentOutOfRangeException("Must be 0 or 1");
                }
	    }
        }
    }
