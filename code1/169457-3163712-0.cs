        public int Compare(Object x, Object y)
        {
            int retVal = 0;
            IComparable valX = x as IComparable;
            IComparable valY = y as IComparable;
            if (valX == null && valY == null)
            {
                return 0;
            }
            if (valX == null)
            { 
                return 1; 
            }
            else if (valY == null)
            {
                return -1;
            }
            return valX.CompareTo(valY);
        }
