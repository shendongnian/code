    /// <Summary>
    /// Compares two classes based only on the value of their X property.
    /// </Summary>
    public class ComparerByX : IEqualityComparer<BaseClass>
    {
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
