    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    using System.Linq.Expressions;
    class StaticPropertyTypeRecursiveEquality<T>
    {
        private static readonly Func<T,T, bool> actualEquals;
        static StaticPropertyTypeRecursiveEquality()
        {
            if (typeof(IEquatable<T>).IsAssignableFrom(typeof(T)) || 
                typeof(T).IsValueType ||
                typeof(T).Equals(typeof(object)))
            {
                actualEquals = 
                    (t1,t2) => EqualityComparer<T>.Default.Equals(t1, t2);
            }
            else 
            {
                List<Func<T,T,bool>> recursionList = new List<Func<T,T,bool>>();
                var getterGeneric = 
                    typeof(StaticPropertyTypeRecursiveEquality<T>)
                        .GetMethod("MakePropertyGetter", 
                            BindingFlags.NonPublic | BindingFlags.Static);
                IEnumerable<PropertyInfo> properties = typeof(T)
                    .GetProperties()
                    .Where(p => p.CanRead);
                foreach (var property in properties)                
                {
                    var specific = getterGeneric
                        .MakeGenericMethod(property.PropertyType);
                    var parameter = Expression.Parameter(typeof(T), "t");
                    var getterExpression = Expression.Lambda(
                        Expression.MakeMemberAccess(parameter, property),
                        parameter);
                    recursionList.Add((Func<T,T,bool>)specific.Invoke(
                        null, 
                        new object[] { getterExpression }));                    
                }
                actualEquals = (t1,t2) =>
                    {
                        foreach (var p in recursionList)
                        {
                            if (t1 == null && t2 == null)
                                return true;
                            if (t1 == null || t2 == null)
                                return false;
                            if (!p(t1,t2))
                                return false;                            
                        }
                        return true;
                    };
            }
        }
        private static Func<T,T,bool> MakePropertyGetter<TProperty>(
            Expression<Func<T,TProperty>> getValueExpression)
        {
            var getValue = getValueExpression.Compile();
            return (t1,t2) =>
                {
                    return StaticPropertyTypeRecursiveEquality<TProperty>
                        .Equals(getValue(t1), getValue(t2));
                };
        }
        public static bool Equals(T t1, T t2)
        {
            return actualEquals(t1,t2);
        }
    }
