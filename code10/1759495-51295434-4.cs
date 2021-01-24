    class ArrayObject
    {
        private BitArray theBits;
        private int hashCode;
        public override bool Equals(object obj)
        {
            if (object == null || GetType() != obj.GetType())
            {
                return false;
            }
            ArrayObject other = (ArrayObject)obj;
            // compare two BitArray objects
            for (var i = 0; i < theBits.Length; ++i)
            {
                if (theBits[i] != other.theBits[i])
                    return false;
            }
            return true;
        }
        public override int GetHashCode()
        {
            return hashCode;
        }
        public ArrayObject(int hash, BitArray bits)
        {
            theBits = bits;
            hashCode = hash;
        }
    }
