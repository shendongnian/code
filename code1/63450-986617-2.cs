    static class MemberCompare
    {
        public static bool Equal<T>(T x, T y)
        {
            return Cache<T>.Compare(x, y);
        }
        static class Cache<T>
        {
            internal static readonly Func<T, T, bool> Compare;
            static Cache()
            {
                var members = typeof(T).GetProperties(
                    BindingFlags.Instance | BindingFlags.Public)
                    .Cast<MemberInfo>().Concat(typeof(T).GetFields(
                    BindingFlags.Instance | BindingFlags.Public)
                    .Cast<MemberInfo>());
                var x = Expression.Parameter(typeof(T), "x");
                var y = Expression.Parameter(typeof(T), "y");
    
                Expression body = null;
                foreach(var member in members)
                {
                    Expression memberEqual;
                    switch (member.MemberType)
                    {
                        case MemberTypes.Field:
                            memberEqual = Expression.Equal(
                                Expression.Field(x, (FieldInfo)member),
                                Expression.Field(y, (FieldInfo)member));
                            break;
                        case MemberTypes.Property:
                            memberEqual = Expression.Equal(
                                Expression.Property(x, (PropertyInfo)member),
                                Expression.Property(y, (PropertyInfo)member));
                            break;
                        default:
                            throw new NotSupportedException(
                                member.MemberType.ToString());
                    }
                    if (body == null)
                    {
                        body = memberEqual;
                    }
                    else
                    {
                        body = Expression.AndAlso(body, memberEqual);
                    }
                }
                if (body == null)
                {
                    Compare = delegate { return true; };
                }
                else
                {
                    Compare = Expression.Lambda<Func<T, T, bool>>(body, x, y)
                                  .Compile();
                }
            }
        }
    }
