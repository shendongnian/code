    public class MyTypeComparer : IEqualityComparer<MyType>
    {
        public MyTypeComparer()
        {    
        }
        
        #region IComparer<MyType> Members
    
        public bool Equals(MyType x, MyType y)
        {
            return string.Equals(x.Id, y.Id);
        }
    
        public int GetHashCode(MyType obj)
        {
            return base.GetHashCode();
        }
    
        #endregion     
    }
