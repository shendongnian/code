    List<int> one = new List<int> { 1, 2, 3, 4, 5 };
    List<int> second=new List<int> { 1, 2, 5, 6 };
    var result = one.Union (second, new EqComparer ());
    foreach( int x in result )
    {
        Console.WriteLine (x);
    }
    Console.ReadLine ();
    #region IEqualityComparer<int> Members
    public class EqComparer : IEqualityComparer<int>
    {
        public bool Equals( int x, int y )
        {
            return x == y;
        }
        public int GetHashCode( int obj )
        {
            return obj.GetHashCode ();
        }
    }
    #endregion
