    public sealed class RndGenerator
    {
        static int m_rndSeed = 0x50000;
        // This is the value that the programmer sets the seed at ProjectData object
        // initialization
        const int CONSTANT_INIT_RNDSEED = 0x50000; 
        // Methods
        private static float GetTimer()
        {
            DateTime now = DateTime.Now;
            return (float)(((((60 * now.Hour) + now.Minute) * 60) + now.Second) + (((double)now.Millisecond) / 1000.0));
        }
        public static void Randomize()
        {
            float timer = GetTimer();
            int rndSeed = m_rndSeed;
            int num = BitConverter.ToInt32(BitConverter.GetBytes(timer), 0);
            num = ((num & 0xffff) ^ (num >> 0x10)) << 8;
            rndSeed = (rndSeed & -16776961) | num;
            m_rndSeed = rndSeed;
        }
        public static void Randomize(double Number)
        {
            Randomize(Number, false);
        }
        public static void Randomize(double Number, bool useHardCodedState)
        {
            int num;
            int rndSeed = 0;
            if (useHardCodedState)
                rndSeed = CONSTANT_INIT_RNDSEED;
            else
                rndSeed = m_rndSeed;
            if (BitConverter.IsLittleEndian)
            {
                num = BitConverter.ToInt32(BitConverter.GetBytes(Number), 4);
            }
            else
            {
                num = BitConverter.ToInt32(BitConverter.GetBytes(Number), 0);
            }
            num = ((num & 0xffff) ^ (num >> 0x10)) << 8;
            rndSeed = (rndSeed & -16776961) | num;
            m_rndSeed = rndSeed;
        }
        public static float Rnd()
        {
            return Rnd(1f);
        }
        public static float Rnd(float Number)
        {
            int rndSeed = m_rndSeed;
            if (Number != 0.0)
            {
                if (Number < 0.0)
                {
                    long num3 = BitConverter.ToInt32(BitConverter.GetBytes(Number), 0);
                    num3 &= (long)0xffffffffL;
                    rndSeed = (int)((num3 + (num3 >> 0x18)) & 0xffffffL);
                }
                rndSeed = (int)(((rndSeed * 0x43fd43fdL) + 0xc39ec3L) & 0xffffffL);
            }
            m_rndSeed = rndSeed;
            return (((float)rndSeed) / 1.677722E+07f);
        }
    }
