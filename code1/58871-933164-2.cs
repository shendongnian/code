    public class SortExpression<T>
    {
        private Expression<Func<T, DateTime?>> DateTimeExpression { get; set; }
        private Expression<Func<T, int?>> intExpression { get; set; }
        private Expression<Func<T, string>> stringExpression { get; set; }
    
        public SortExpression(Expression<Func<T, DateTime?>> expression)
        {
            DateTimeExpression = expression;
        }
    
        public SortExpression(Expression<Func<T, int?>> expression)
        {
            intExpression = expression;
        }
    
        public SortExpression(Expression<Func<T, string>> expression)
        {
            stringExpression = expression;
        }
    
        public IQueryable<T> ApplySortExpression(IQueryable<T> elements, bool? descending)
        {
            if (DateTimeExpression != null)
            {
                if (descending.HasValue && descending.Value)
                    return elements.OrderByDescending(DateTimeExpression);
                else
                    return elements.OrderBy(DateTimeExpression);
            }
            else if (intExpression != null)
            {
                if (descending.HasValue && descending.Value)
                    return elements.OrderByDescending(intExpression);
                else
                    return elements.OrderBy(intExpression);
            }
            else if (stringExpression != null)
            {
                if (descending.HasValue && descending.Value)
                    return elements.OrderByDescending(stringExpression);
                else
                    return elements.OrderBy(stringExpression);
            }
            else
                throw new Exception("Unsuported sortkey type");
        }
    }
