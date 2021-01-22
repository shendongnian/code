    public class NumericStringComparer : IComparer<String>
    {
        public int Compare(string x, string y)
        {
            float xNumber, yNumber;
            if (!float.TryParse(x, out xNumber))
            {
                return -1;
            }
            if (!float.TryParse(y, out yNumber))
            {
                return -1;
            }
            if (xNumber == yNumber)
            {
                return 0;
            }
            else
            {
                return (xNumber > yNumber) ? 1 : -1;
            }
        }
    }
