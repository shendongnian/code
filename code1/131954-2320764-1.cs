    public override int GetHashCode()
    {
        int hc = this.length;
        for (int i = 0; i < this.Array.Length; i++)
        {
            if (i < this.Array.Length - 1)
            {
                hc ^= this.Array[i];
            }
            else
            {
                int shift = 0x20 - (this.length % 0x20);
                hc ^= this.Array[this.Array.Length - 1] << shift;
            }
        }
        return hc;
    }
