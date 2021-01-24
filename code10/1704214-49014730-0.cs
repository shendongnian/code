    public class MyCustomSort : IComparer
    {
        public int Compare(object x, object y)
        {
            //put nulls first
            if (x == null) return 1;
            if (y == null) return -1;
            string x1, y1;            
            x1 = x.ToString();
            y1 = y.ToString();
            //put Ns second after nulls
            if (x1 == "N") return -1;
            if (y1 == "N") return 1;
            return x.CompareTo(y); //assuming these are doubles
        }
    }
