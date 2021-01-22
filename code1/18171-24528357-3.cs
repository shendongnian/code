    public static class LambdaCompare
    {
        public static bool Eq<TSource, TValue>(
            Expression<Func<TSource, TValue>> x,
            Expression<Func<TSource, TValue>> y)
        {
            return ExpressionsEqual(x, y, null, null);
        }
        public static Expression<Func<Expression<Func<TSource, TValue>>, bool>> Eq<TSource, TValue>(Expression<Func<TSource, TValue>> y)
        {
            return x => ExpressionsEqual(x, y, null, null);
        }
        private static bool ExpressionsEqual(Expression x, Expression y, LambdaExpression rootX, LambdaExpression rootY)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x == null || y == null) return false;
            var valueX = TryCalculateConstant(x);
            var valueY = TryCalculateConstant(y);
            if (valueX.IsDefined && valueY.IsDefined)
                return ValuesEqual(valueX.Value, valueY.Value);
            if (x.NodeType != y.NodeType
                || x.Type != y.Type) return false;
            if (x is LambdaExpression)
            {
                var lx = (LambdaExpression) x;
                var ly = (LambdaExpression) y;
                var paramsX = lx.Parameters;
                var paramsY = ly.Parameters;
                return CollectionsEqual(paramsX, paramsY, lx, ly) && ExpressionsEqual(lx.Body, ly.Body, lx, ly);
            }
            if (x is MemberExpression)
            {
                var mex = (MemberExpression) x;
                var mey = (MemberExpression) y;
                return Equals(mex.Member, mey.Member) && ExpressionsEqual(mex.Expression, mey.Expression, rootX, rootY);
            }
            if (x is BinaryExpression)
            {
                var bx = (BinaryExpression) x;
                var by = (BinaryExpression) y;
                return bx.Method == @by.Method && ExpressionsEqual(bx.Left, @by.Left, rootX, rootY) &&
                       ExpressionsEqual(bx.Right, @by.Right, rootX, rootY);
            }
            if (x is ParameterExpression)
            {
                var px = (ParameterExpression) x;
                var py = (ParameterExpression) y;
                return rootX.Parameters.IndexOf(px) == rootY.Parameters.IndexOf(py);
            }
            if (x is MethodCallExpression)
            {
                var cx = (MethodCallExpression)x;
                var cy = (MethodCallExpression)y;
                return cx.Method == cy.Method
                       && ExpressionsEqual(cx.Object, cy.Object, rootX, rootY)
                       && CollectionsEqual(cx.Arguments, cy.Arguments, rootX, rootY);
            }
            throw new NotImplementedException(x.ToString());
        }
        private static bool ValuesEqual(object x, object y)
        {
            if (ReferenceEquals(x, y))
                return true;
            if (x is ICollection && y is ICollection)
                return CollectionsEqual((ICollection) x, (ICollection) y);
            return Equals(x, y);
        }
        private static ConstantValue TryCalculateConstant(Expression e)
        {
            if (e is ConstantExpression)
                return new ConstantValue(true, ((ConstantExpression) e).Value);
            if (e is MemberExpression)
            {
                var me = (MemberExpression) e;
                var parentValue = TryCalculateConstant(me.Expression);
                if (parentValue.IsDefined)
                {
                    var result =
                        me.Member is FieldInfo
                            ? ((FieldInfo) me.Member).GetValue(parentValue.Value)
                            : ((PropertyInfo) me.Member).GetValue(parentValue.Value);
                    return new ConstantValue(true, result);
                }
            }
            if (e is NewArrayExpression)
            {
                var ae = ((NewArrayExpression) e);
                var result = ae.Expressions.Select(TryCalculateConstant);
                if (result.All(i => i.IsDefined))
                    return new ConstantValue(true, result.Select(i => i.Value).ToArray());
            }
            return default(ConstantValue);
        }
        private static bool CollectionsEqual(IEnumerable<Expression> x, IEnumerable<Expression> y, LambdaExpression rootX, LambdaExpression rootY)
        {
            return x.Count() == y.Count()
                   && x.Select((e, i) => new {Expr = e, Index = i})
                       .Join(y.Select((e, i) => new { Expr = e, Index = i }),
                             o => o.Index, o => o.Index, (xe, ye) => new { X = xe.Expr, Y = ye.Expr })
                       .All(o => ExpressionsEqual(o.X, o.Y, rootX, rootY));
        }
        private static bool CollectionsEqual(ICollection x, ICollection y)
        {
            return x.Count == y.Count
                   && x.Cast<object>().Select((e, i) => new { Expr = e, Index = i })
                       .Join(y.Cast<object>().Select((e, i) => new { Expr = e, Index = i }),
                             o => o.Index, o => o.Index, (xe, ye) => new { X = xe.Expr, Y = ye.Expr })
                       .All(o => Equals(o.X, o.Y));
        }
        private struct ConstantValue
        {
            public ConstantValue(bool isDefined, object value) : this()
            {
                IsDefined = isDefined;
                Value = value;
            }
            public bool IsDefined { get; private set; }
            public object Value { get; private set; }
        }
    }
