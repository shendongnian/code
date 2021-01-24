    public class Comparison
    {
        public IComparable Left { get; }
        public CompareType CompareType { get; }
        public IComparable Right { get; }
        public Comparison(IComparable left, CompareType compareType, IComparable right) 
        {
            Left = left;
            CompareType = compareType;
            Right = right;
        }
        public bool Excecute()
        {
            switch (CompareType)
            {
                case CompareType.Equals:
                    return IsTypeMatch ? Left.CompareTo(Right) == 0 : Left.ToString().Equals(Right.ToString());
                case CompareType.NotEquals:
                    return IsTypeMatch ? Left.CompareTo(Right) != 0 : !Left.ToString().Equals(Right.ToString());
                case CompareType.GreaterThan:
                    return IsTypeMatch ? Left.CompareTo(Right) != 0 : Left.ToString().CompareTo(Right.ToString()) > 0;
                case CompareType.LessThan:
                    return IsTypeMatch ? Left.CompareTo(Right) != 0 : Left.ToString().CompareTo(Right.ToString()) < 0;
                default:
                    throw new NotImplementedException();
            }
        }
    
        private bool IsTypeMatch => Left.GetType().Equals(Right.GetType());
    }
    public enum CompareType
    {
        Equals = 1,
        NotEquals = 2,
        GreaterThan = 3,
        LessThan = 4,
    }
