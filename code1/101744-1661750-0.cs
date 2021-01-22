    public class ComparerByX : IEqualityComparer<BaseClass>
    {
         // implement Equals and GetHashCode to compare only the "X" property
         #region IEqualityComparer<BaseClass> Members
       
         public bool Equals(BaseClass a, BaseClass b)
         {
             return (a.X == b.X);
         }
         public int GetHashCode(BaseClass obj)
         {
             return obj.X.GetHashCode();
         }
  
         #endregion
    }
