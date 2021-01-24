    private Expression<Func<EmployeeAppraisal, bool>> buildFilterExpression(IEnumerable<Segment> segments)
    {
        Expression<Func<EmployeeAppraisal, bool>> exp = c => false;
    
        foreach (var segment in segments)
        {
            Expression<Func<EmployeeAppraisal, bool>> filter = x => x.TotalResult >= segment.Min && x.TotalResult <= segment.Max;
            exp = Expression.Lambda<Func<EmployeeAppraisal, bool>>(Expression.OrElse(exp.Body,
                new ExpressionParameterReplacer(filter.Parameters, exp.Parameters).Visit(filter.Body)), exp.Parameters);
        }
    
        return exp;
    }
    
    private class ExpressionParameterReplacer : ExpressionVisitor
    {
        public ExpressionParameterReplacer(IList<ParameterExpression> fromParameters, IList<ParameterExpression> toParameters)
        {
            ParameterReplacements = new Dictionary<ParameterExpression, ParameterExpression>();
            for (int i = 0; i != fromParameters.Count && i != toParameters.Count; i++)
                ParameterReplacements.Add(fromParameters[i], toParameters[i]);
        }
                
        private IDictionary<ParameterExpression, ParameterExpression> ParameterReplacements
        {
            get;
            set;
        }
        
        protected override Expression VisitParameter(ParameterExpression node)
        {
            ParameterExpression replacement;
            if (ParameterReplacements.TryGetValue(node, out replacement))
                node = replacement;
            return base.VisitParameter(node);
        }
    } 
