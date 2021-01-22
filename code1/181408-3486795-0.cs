       public class LambdaCriteries<T> : List<Expression<Func<T, bool>>>
    {
        public Expression<Func<T, bool>> GetFinalLambdaExpression()
        {
            var par = Expression.Parameter(typeof(T));
            var intial = Expression.Invoke(this.First(),par);
            var sec = Expression.Invoke(this.Skip(1).First(),par);
            BinaryExpression binaryExpression = Expression.And(intial, sec);
            if (this.Count> 2)
            {
                foreach (var ex in this.ToList().Skip(2))
                {
                    binaryExpression = Expression.And(binaryExpression, Expression.Invoke(ex, par));
                }
                return Expression.Lambda<Func<T, bool>>(binaryExpression,par);
            }
            else
            {
                return Expression.Lambda<Func<T, bool>>(binaryExpression,par);
            }
        }
    }
