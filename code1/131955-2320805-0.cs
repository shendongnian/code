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
                // since padding bits are forced to zero in the constructor,
                //  we can test those for equality just as well and the valid
                //  bits
                return false;
            }
        }
    
        return true;
    }
    
    
    public override int GetHashCode()
    {
        int hc = this.length;
    
        for (int i = 0; i < this.Array.Length; i++)
        {
            // since padding bits are forced to zero in the constructor,
            //  we can mix those into the hashcode no problem
            
            hc ^= this.Array[i];
        }
    
        return hc;
    }
