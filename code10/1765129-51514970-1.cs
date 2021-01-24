    class ItemComparer : IEqualityComparer<Item>
    {
        public bool Equals(Item i1, Item i2)
        {
            if (i1 == null && i2 == null)
                return true;
            else if (i2 == null | i1 == null)
                return false;
            else if (i2.A == i1.A
                && i2.B == i1.B
                && i2.C == i1.C)
                return true;
            else
                return false;
        }
        public int GetHashCode(Item i)
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + i.A.GetHashCode();
                hash = hash * 23 + i.B.GetHashCode();
                hash = hash * 23 + i.C.GetHashCode();
                return hash;
            }
        }
    }
