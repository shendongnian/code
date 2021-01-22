    using System;
    using System.Linq.Expressions;
    public class Program
    {
        public static Expression<Func<T1, TResult>> Bind2nd<T1, T2, TResult>(Expression<Func<T1, T2, TResult>> source, T2 argument)
        {
            Expression arg2 = Expression.Constant(argument, typeof (T2));
            Expression newBody = new Rewriter(source.Parameters[1], arg2).Visit(source.Body);
            return Expression.Lambda<Func<T1, TResult>>(newBody, source.Parameters[0]);
        }
        public static void Main(string[] args)
        {
            Expression<Func<string, string, int>> f = (a, b) => a.Length + b.Length;
            Console.WriteLine(f); // (a, b) => (a.Length + b.Length)
            Console.WriteLine(Bind2nd(f, "1")); // a => (a.Length + "1".Length)
        }
        #region Nested type: Rewriter
        private class Rewriter : ExpressionVisitor
        {
            private readonly Expression candidate_;
            private readonly Expression replacement_;
            public Rewriter(Expression candidate, Expression replacement)
            {
                candidate_ = candidate;
                replacement_ = replacement;
            }
            public override Expression Visit(Expression node)
            {
                return node == candidate_ ? replacement_ : base.Visit(node);
            }
        }
        #endregion
    }
