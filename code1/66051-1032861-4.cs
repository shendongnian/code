    class MyComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            int xVal, yVal;
            var xIsVal = int.TryParse( x, out xVal );
            var yIsVal = int.TryParse( y, out yVal );
    
            if (xIsVal && yIsVal)   // both are numbers...
                return xVal.CompareTo(yVal);
            if (!xIsVal && !yIsVal) // both are strings...
                return x.CompareTo(y);
            if (xIsVal)             // x is a number, sort first
                return -1;
            return 1;               // x is a string, sort last
        }
    }
    var input = new[] {"a", "1", "10", "b", "2", "c"};
    var e = input.OrderBy( s => s, new MyComparer() );
