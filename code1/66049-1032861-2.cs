    class MyComparer : IComparer<string>
    {
        #region IComparer Members
        public int Compare(string x, string y)
        {
            int xVal, yVal;
            var xIsVal = int.TryParse( x, out xVal );
            var yIsVal = int.TryParse( y, out yVal );
    
            if (xIsVal && yIsVal)
                return xVal.CompareTo(yVal);
            if (x.Equals(y))
                return 0;
            if (xIsVal)
                return -1;
            return 1;
        }
        #endregion
    }
    var input = new[] {"a", "1", "10", "b", "2", "c"};
    var e = input.OrderBy( s => s, new MyComparer() );
