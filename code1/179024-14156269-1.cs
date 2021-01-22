    using System;
    using System.Linq.Expressions;
    using NUnit.Framework;
    
    namespace Icodeon.Hotwire.Tests.Framework
    {
        public static class QuickAssert
        {
            public static void Ensure<TSource>(this TSource source, params Expression<Func<TSource, bool>>[] actions)
            {
                foreach (var expression in actions)
                {
                    Ensure(source,expression);
                }
            }
    
            public static void Ensure<TSource>(this TSource source, Expression<Func<TSource, bool>> action)
            {
                var propertyCaller = action.Compile();
                bool result = propertyCaller(source);
                if (result) return;
                Assert.Fail("Property check failed -> " + action.ToString());
            }
        }
    }
