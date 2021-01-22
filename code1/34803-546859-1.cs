    enum LineComparisonMode
    {
       ///<summary>the order of the line numbers matters, default</summary>
       Ordered = 0, 
       ///<summary>the order of the line numbers doesn't matter
       /// Has a higher cost to the default.
       ///</summary>
       Unordered = 1,
    } 
    class ListLineComparer : IEqualityComparer<List<Class>>
    {
        class LineComparer : IComparer<Class>
        {
            public bool Equals(Class x, Class y)
            {
                return x.IDLinea == y.IDLinea;
            }
            public int GetHashCode(Class x)
            {
                return x.IDLinea;
            }
        }
 
        private readonly LineComparer lines;
        private readonly LineComparisonMode mode;
        public ListLineComparer() {}
        public ListLineComparer(LineComparisonMode mode)
        { 
            this.mode = mode;
        }
        public bool Equals(List<Class> x, List<Class> y)
        {
            if (Mode == LineComparisonMode.Ordered)
                return x.SequenceEquals(y, lines);
            else
                return x.OrderBy(Line).SequenceEquals(y.OrderBy(Line), lines);
        }
        private static int Line(Class c)
        {
            return c.IDLinea;
        }
        
        public int GetHashCode(List<Class> x)
        {
            //this is not a good hash (though correct) 
            // but not relevant to current question
            return x.Sum(c => c.IDLinea);
        }
    }
    // assume List <List<Class>> L = new List<List<Class>>(); from question
    var result = L.Distinct(new ListLineComparer()); 
