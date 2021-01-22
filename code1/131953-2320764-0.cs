    public bool Equals(ImmutableBitArray other)
    {
        if (this.length != other.length)
        {
            return false;
        }
        for (int i = 0; i < this.Array.Length; i++)
        {
            if (this.Array[i] != other.Array[i])
            {
                // This does not necessarily mean that the relevant bits of the integer arrays are different.
                // Is this before the last element in the integer arrays?
                if (i < this.Array.Length - 1)
                {
                    // If so, then the objects are not equal.
                    return false;
                }
                // If this is the last element in the array we only need to be concerned about the bits
                // up to the length of the bit array.
                int shift = 0x20 - (this.length % 0x20);
                if (this.Array[i] << shift != other.Array[i] << shift)
                {
                    return false;
                }
            }
        }
        return true;
    }
