    class ArrayObject2
    {
        private long l1;
        private long l2;
        private long l3;
        public ArrayObject2(int[] theArray)
        {
            for (int i = 0; i < theArray.Length; ++i)
            {
                var rem = theArray[i] % 63;
                int bitVal = 1 << rem;
                if (rem < 64) l1 |= bitVal;
                else if (rem < 128) l2 |= bitVal;
                else l3 |= bitVal;
            }
        }
        public override bool Equals(object obj)
        {
            var other = obj as ArrayObject2;
            if (other == null) return false;
            return l1 == other.l1 && l2 == other.l2 && l3 == other.l3;
        }
        public override int GetHashCode()
        {
            // very simple, and not very good hash function.
            return (int)l1;
        }
    }
