    public class GenericComparer<T> : IComparer<T>
     {
         public string SortExpression { get; set; }
         public int SortDirection { get; set; } // 0:Ascending, 1:Descending
    
         public GenericComparer(string sortExpression, int sortDirection)
         {
             this.SortExpression = sortExpression;
             this.SortDirection = sortDirection;
         }
         public GenericComparer() { }
    
         #region IComparer<T> Members
         public int Compare(T x, T y)
         {
             PropertyInfo propertyInfo = typeof(T).GetProperty(SortExpression);
             IComparable obj1 = (IComparable)propertyInfo.GetValue(x, null);
             IComparable obj2 = (IComparable)propertyInfo.GetValue(y, null);
    
             if (SortDirection == 0)
             {
                 return obj1.CompareTo(obj2);
             }
             else return obj2.CompareTo(obj1);
         }
         #endregion
     }
