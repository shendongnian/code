    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    public static class StringComparerQueryableWrapper
    {
        public static IQueryable<T> AsStringComparer<T>(this IQueryable<T> query, StringComparison comparisonType)
        {
            return new StringComparerQueryableWrapper<T>(query, comparisonType);
        }
    }
    public class StringComparerQueryableWrapper<T> : IQueryable<T>, IQueryable, IQueryProvider
    {
        private readonly IQueryable<T> baseQuery;
        public readonly StringComparison ComparisonType;
        public StringComparerQueryableWrapper(IQueryable<T> baseQuery, StringComparison comparisonType)
        {
            this.baseQuery = baseQuery;
            this.ComparisonType = comparisonType;
        }
        Expression IQueryable.Expression => baseQuery.Expression;
        Type IQueryable.ElementType => baseQuery.ElementType;
        IQueryProvider IQueryable.Provider => this;
        IQueryable IQueryProvider.CreateQuery(Expression expression)
        {
            Type type = expression.Type;
            var iqueryableT = type.GetInterfaces().Where(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IQueryable<>)).Single();
            Type type2 = iqueryableT.GetGenericArguments()[0];
            var thisType = typeof(StringComparerQueryableWrapper<>).MakeGenericType(typeof(T));
            var createQueryMethod = thisType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic).Where(x => x.Name == "System.Linq.IQueryProvider.CreateQuery" && x.IsGenericMethod).Single().MakeGenericMethod(type2);
            var queryable = (IQueryable)createQueryMethod.Invoke(this, new object[] { expression });
            return queryable;
        }
        IQueryable<TElement> IQueryProvider.CreateQuery<TElement>(Expression expression)
        {
            var expression2 = TransformExpression(expression);
            var query = baseQuery.Provider.CreateQuery<TElement>(expression2);
            return new StringComparerQueryableWrapper<TElement>(query, ComparisonType);
        }
        object IQueryProvider.Execute(Expression expression)
        {
            var expression2 = TransformExpression(expression);
            return baseQuery.Provider.Execute(expression2);
        }
        TResult IQueryProvider.Execute<TResult>(Expression expression)
        {
            var expression2 = TransformExpression(expression);
            return baseQuery.Provider.Execute<TResult>(expression2);
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return baseQuery.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return baseQuery.GetEnumerator();
        }
        private Expression TransformExpression(Expression expression)
        {
            Expression expression2 = new StringComparerExpressionTranformer(ComparisonType).Visit(expression);
            return expression2;
        }
        private class StringComparerExpressionTranformer : ExpressionVisitor
        {
            private readonly StringComparison comparisonType;
            private static readonly IReadOnlyDictionary<MethodInfo, Func<MethodCallExpression, StringComparison, Expression>> transformers;
            private static readonly IReadOnlyDictionary<MethodInfo, Func<BinaryExpression, StringComparison, Expression>> transformers2;
            // https://stackoverflow.com/a/32764110/613130
            private static readonly IReadOnlyDictionary<StringComparison, StringComparer> comparisonToComparer = new Dictionary<StringComparison, System.StringComparer>
            {
                { StringComparison.CurrentCulture, StringComparer.CurrentCulture },
                { StringComparison.CurrentCultureIgnoreCase, StringComparer.CurrentCultureIgnoreCase },
                { StringComparison.InvariantCulture, StringComparer.InvariantCulture },
                { StringComparison.InvariantCultureIgnoreCase, StringComparer.InvariantCultureIgnoreCase },
                { StringComparison.Ordinal, StringComparer.Ordinal },
                { StringComparison.OrdinalIgnoreCase, StringComparer.OrdinalIgnoreCase }
            };
            static StringComparerExpressionTranformer()
            {
                var transformers = new Dictionary<MethodInfo, Func<MethodCallExpression, StringComparison, Expression>>();
                {
                    // string.Compare("foo", "bar")
                    var method = typeof(string).GetMethod(nameof(string.Compare), BindingFlags.Static | BindingFlags.Public, null, new[] { typeof(string), typeof(string) }, null);
                    transformers.Add(method, Compare);
                }
                {
                    // string.Compare("foo", 0, "bar", 0, 3)
                    var method = typeof(string).GetMethod(nameof(string.Compare), BindingFlags.Static | BindingFlags.Public, null, new[] { typeof(string), typeof(int), typeof(string), typeof(int), typeof(int) }, null);
                    transformers.Add(method, CompareIndexLength);
                }
                {
                    // "foo".CompareTo("bar")
                    var method = typeof(string).GetMethod(nameof(string.CompareTo), BindingFlags.Instance | BindingFlags.Public, null, new[] { typeof(string) }, null);
                    transformers.Add(method, CompareTo);
                }
                {
                    // "foo".Contains("bar")
                    var method = typeof(string).GetMethod(nameof(string.Contains), BindingFlags.Instance | BindingFlags.Public, null, new[] { typeof(string) }, null);
                    transformers.Add(method, Contains);
                }
                {
                    // string.Equals("foo", "bar")
                    var method = typeof(string).GetMethod(nameof(string.Equals), BindingFlags.Static | BindingFlags.Public, null, new[] { typeof(string), typeof(string) }, null);
                    transformers.Add(method, EqualsStatic);
                }
                {
                    // "foo".Equals("bar")
                    var method = typeof(string).GetMethod(nameof(string.Equals), BindingFlags.Instance | BindingFlags.Public, null, new[] { typeof(string) }, null);
                    transformers.Add(method, EqualsInstance);
                }
                {
                    // Enumerable.Contains<TSource>(source, "foo")
                    var method = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                  where x.Name == nameof(Enumerable.Contains)
                                  let args = x.GetGenericArguments()
                                  where args.Length == 1
                                  let pars = x.GetParameters()
                                  where pars.Length == 2 &&
                                      pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                      pars[1].ParameterType == args[0]
                                  select x).Single();
                    // Enumerable.Contains<string>(source, "foo")
                    var method2 = method.MakeGenericMethod(typeof(string));
                    transformers.Add(method2, EnumerableContains);
                }
                // TODO: all the various Array.Find*, Array.IndexOf
                StringComparerExpressionTranformer.transformers = transformers;
                var transformers2 = new Dictionary<MethodInfo, Func<BinaryExpression, StringComparison, Expression>>();
                {
                    // ==
                    var method = typeof(string).GetMethod("op_Equality", BindingFlags.Static | BindingFlags.Public, null, new[] { typeof(string), typeof(string) }, null);
                    transformers2.Add(method, OpEquality);
                }
                {
                    // !=
                    var method = typeof(string).GetMethod("op_Inequality", BindingFlags.Static | BindingFlags.Public, null, new[] { typeof(string), typeof(string) }, null);
                    transformers2.Add(method, OpInequality);
                }
                StringComparerExpressionTranformer.transformers2 = transformers2;
            }
            public StringComparerExpressionTranformer(StringComparison comparisonType)
            {
                this.comparisonType = comparisonType;
            }
            // methods
            protected override Expression VisitMethodCall(MethodCallExpression node)
            {
                Func<MethodCallExpression, StringComparison, Expression> transformer;
                if (transformers.TryGetValue(node.Method, out transformer))
                {
                    Expression node2 = transformer(node, comparisonType);
                    return Visit(node2);
                }
                return base.VisitMethodCall(node);
            }
            // operators
            protected override Expression VisitBinary(BinaryExpression node)
            {
                Func<BinaryExpression, StringComparison, Expression> transformer;
                if (node.Method != null && transformers2.TryGetValue(node.Method, out transformer))
                {
                    Expression node2 = transformer(node, comparisonType);
                    return Visit(node2);
                }
                return base.VisitBinary(node);
            }
            private static readonly MethodInfo StringEqualsStatic = typeof(string).GetMethod(nameof(string.Equals), BindingFlags.Static | BindingFlags.Public, null, new[] { typeof(string), typeof(string), typeof(StringComparison) }, null);
            private static readonly MethodInfo StringEqualsInstance = typeof(string).GetMethod(nameof(string.Equals), BindingFlags.Instance | BindingFlags.Public, null, new[] { typeof(string), typeof(StringComparison) }, null);
            private static readonly MethodInfo StringCompareStatic = typeof(string).GetMethod(nameof(string.Compare), BindingFlags.Static | BindingFlags.Public, null, new[] { typeof(string), typeof(string), typeof(StringComparison) }, null);
            private static readonly MethodInfo StringCompareIndexLengthStatic = typeof(string).GetMethod(nameof(string.Compare), BindingFlags.Static | BindingFlags.Public, null, new[] { typeof(string), typeof(int), typeof(string), typeof(int), typeof(int), typeof(StringComparison) }, null);
            private static readonly MethodInfo StringIndexOfInstance = typeof(string).GetMethod(nameof(string.IndexOf), BindingFlags.Instance | BindingFlags.Public, null, new[] { typeof(string), typeof(StringComparison) }, null);
            private static readonly MethodInfo EnumerableContainsStatic = (from x in typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                                                                           where x.Name == nameof(Enumerable.Contains)
                                                                           let args = x.GetGenericArguments()
                                                                           where args.Length == 1
                                                                           let pars = x.GetParameters()
                                                                           where pars.Length == 3 &&
                                                                               pars[0].ParameterType == typeof(IEnumerable<>).MakeGenericType(args[0]) &&
                                                                               pars[1].ParameterType == args[0] &&
                                                                               pars[2].ParameterType == typeof(IEqualityComparer<>).MakeGenericType(args[0])
                                                                           select x).Single().MakeGenericMethod(typeof(string));
            private static Expression Compare(MethodCallExpression exp, StringComparison comparisonType)
            {
                return Expression.Call(StringCompareStatic, exp.Arguments[0], exp.Arguments[1], Expression.Constant(comparisonType));
            }
            private static Expression CompareIndexLength(MethodCallExpression exp, StringComparison comparisonType)
            {
                return Expression.Call(StringCompareIndexLengthStatic, exp.Arguments[0], exp.Arguments[1], exp.Arguments[2], exp.Arguments[3], exp.Arguments[4], Expression.Constant(comparisonType));
            }
            private static Expression CompareTo(MethodCallExpression exp, StringComparison comparisonType)
            {
                return Expression.Call(StringCompareStatic, exp.Object, exp.Arguments[0], Expression.Constant(comparisonType));
            }
            private static Expression Contains(MethodCallExpression exp, StringComparison comparisonType)
            {
                // No "".Contains(, StringComparison). Translate to "".IndexOf(, StringComparison) != -1
                return Expression.NotEqual(Expression.Call(exp.Object, StringIndexOfInstance, exp.Arguments[0], Expression.Constant(comparisonType)), Expression.Constant(-1));
            }
            private static Expression EqualsStatic(MethodCallExpression exp, StringComparison comparisonType)
            {
                return Expression.Call(StringEqualsStatic, exp.Arguments[0], exp.Arguments[1], Expression.Constant(comparisonType));
            }
            private static Expression EqualsInstance(MethodCallExpression exp, StringComparison comparisonType)
            {
                return Expression.Call(exp.Object, StringEqualsInstance, exp.Arguments[0], Expression.Constant(comparisonType));
            }
            private static Expression EnumerableContains(MethodCallExpression exp, StringComparison comparisonType)
            {
                StringComparer comparer = comparisonToComparer[comparisonType];
                return Expression.Call(EnumerableContainsStatic, exp.Arguments[0], exp.Arguments[1], Expression.Constant(comparer));
            }
            private static Expression OpEquality(BinaryExpression exp, StringComparison comparisonType)
            {
                return Expression.Call(StringEqualsStatic, exp.Left, exp.Right, Expression.Constant(comparisonType));
            }
            private static Expression OpInequality(BinaryExpression exp, StringComparison comparisonType)
            {
                return Expression.Not(Expression.Call(StringEqualsStatic, exp.Left, exp.Right, Expression.Constant(comparisonType)));
            }
        }
    }
