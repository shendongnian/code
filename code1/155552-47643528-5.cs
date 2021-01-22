    public class DynamicSortExpression<T>
    {
        /// <summary>
        /// Creates a new ascending DynamicSortExpression 
        /// </summary>
        /// <param name="keySelector">A MemberExpression identifying the property to sort on</param>
        public DynamicSortExpression(Expression<Func<T, object>> keySelector) : this(keySelector, false)
        {
        }
        public DynamicSortExpression(Expression<Func<T, object>> keySelector, bool descending)
        {
            this.KeySelector = keySelector;
            this.Desc = descending;
        }
        /// <summary>
        /// Gets the expression that selects the property of T to sort on
        /// </summary>
        public Expression<Func<T, object>> KeySelector { get; }
        /// <summary>
        /// Gets sort expression is in ascending or descending order
        /// </summary>
        public bool Desc { get; }
    }
