    public class MyComparer : Comparer<string>
    {
        public override int Compare(string x, string y)
        {
            int xNumber;
            int yNumber;
            var xIsNumber = int.TryParse(x, out xNumber);
            var yIsNumber = int.TryParse(y, out yNumber);
            if (xIsNumber && yIsNumber)
            {
                return xNumber.CompareTo(yNumber);
            }
            if (xIsNumber)
            {
                return -1;
            }
            if (yIsNumber)
            {
                return 1;
            }
            return x.CompareTo(y);
        }
    }
