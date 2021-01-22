    public bool Equals(ImmutableBitArray other)
    {
        if (this.length != other.length)
        {
            return false;
        }
        
        int finalIndex = this.Array.Length - 1;
        for (int i = 0; i < finalIndex; i++)
        {
            if (this.Array[i] != other.Array[i])
            {
                return false;
            }
        }
        
        // check the last array element, making sure to ignore padding bits
        
        int shift = 32 - (this.length % 32);
        if (shift == 32) {
            // the last array element has no padding bits - don't shift
            shift = 0;
        }
        
        if (this.Array[finalIndex] << shift != other.Array[finalIndex] << shift)
        {
            return false;
        }
        return true;
    }
