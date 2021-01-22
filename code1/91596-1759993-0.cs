            /// <summary>
        /// Check if two dates are same
        /// </summary>
        /// <typeparam name="TElement">Type</typeparam>
        /// <param name="valueSelector">date field</param>
        /// <param name="value">date compared</param>
        /// <returns>bool</returns>
        public Expression<Func<TElement, bool>> IsSameDate<TElement>(Expression<Func<TElement, DateTime>> valueSelector, DateTime value)
        {
            ParameterExpression p = valueSelector.Parameters.Single();
            
            var antes = Expression.GreaterThanOrEqual(valueSelector.Body, Expression.Constant(value.Date, typeof(DateTime)));
            var despues = Expression.LessThan(valueSelector.Body, Expression.Constant(value.AddDays(1).Date, typeof(DateTime)));
            Expression body = Expression.And(antes, despues);
            return Expression.Lambda<Func<TElement, bool>>(body, p);
        }
