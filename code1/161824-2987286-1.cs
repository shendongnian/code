    class Program
    {
        static void Main(string[] args)
        {
            var g = new GlorifiedInt(7);
            g.Bits[0] = false;
            Console.WriteLine(g.Value); // prints "6"
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
            public bool this[int index]
	        {
                get 
                {
                    if (index < 0 || index > 31)
                        throw new IndexOutOfRangeException("BitAcessor");
                    return (1 & (gi.m_val >> index)) == 1; 
                }
		        set 
                {
                    if (index < 0 || index > 31)
                        throw new IndexOutOfRangeException("BitAcessor");
                    if (value)
                        gi.m_val |= 1 << index;
                    else
                        gi.m_val &= ~(1 << index);
                }
	    }
        }
    }
