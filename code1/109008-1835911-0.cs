    public class MaximalLFSR
    {
        private int GetFeedbackSize(uint v)
        {
            uint r = 0;
            while ((v >>= 1) != 0)
            {
              r++;
            }
            if (r < 4)
                r = 4;
            return (int)r;
        }
        static uint[] _feedback = new uint[] {
            0x9, 0x17, 0x30, 0x44, 0x8e,
            0x108, 0x20d, 0x402, 0x829, 0x1013, 0x203d, 0x4001, 0x801f,
            0x1002a, 0x2018b, 0x400e3, 0x801e1, 0x10011e, 0x2002cc, 0x400079, 0x80035e,
            0x1000160, 0x20001e4, 0x4000203, 0x8000100, 0x10000235, 0x2000027d, 0x4000016f, 0x80000478
        };
        private uint GetFeedbackTerm(int bits)
        {
            if (bits < 4 || bits >= 28)
                throw new ArgumentOutOfRangeException("bits");
            return _feedback[bits];
        }
        public IEnumerable<int> RandomIndexes(int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException("count");
            int bitsForFeedback = GetFeedbackSize((uint)count);
            Random r = new Random();
            uint i = (uint)(r.Next(1, count - 1));
            uint feedback = GetFeedbackTerm(bitsForFeedback);
            int valuesReturned = 0;
            while (valuesReturned < count)
            {
                if ((i & 1) != 0)
                {
                    i = (i >> 1) ^ feedback;
                }
                else {
                    i = (i >> 1);
                }
                if (i <= count)
                {
                    valuesReturned++;
                    yield return (int)(i-1);
                }
            }
        }
    }
