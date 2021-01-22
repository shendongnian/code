    public class MyClass
    {
        public DateTime MonthYear { get; set; }
        public int Quantity { get; set; }
    }
    
    public class MyClassEqualityComparer : IEqualityComparer<MyClass>
    {
        #region IEqualityComparer<MyClass> Members
    
        public bool Equals(MyClass x, MyClass y)
        {
            return x.MonthYear == y.MonthYear;
        }
    
        public int GetHashCode(MyClass obj)
        {
            return obj.MonthYear.GetHashCode();
        }
    
        #endregion
    }
