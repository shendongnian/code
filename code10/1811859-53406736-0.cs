    public static class Swapper
    {
        /// <summary>
        /// Key used for look-ups.
        /// </summary>
        private struct Key
        {
            private readonly Type _tt1;
            private readonly Type _tt2;
            private readonly MemberInfo _m11;
            private readonly MemberInfo _m12;
    
            public Key(Type t1, Type t2, MemberInfo m1, MemberInfo m2)
            {
                _tt1 = t1;
                _tt2 = t2;
                _m11 = m1;
                _m12 = m2;
            }
    
            public override bool Equals(object obj)
            {
                switch (obj)
                {
                    case Key key:
                        return _tt1 == key._tt1 && _tt2 == key._tt2 && _m11 == key._m11 && _m12 == key._m12;
    
                    default:
                        return false;
                }
            }
    
            public override int GetHashCode()
            {
                unchecked
                {
                    var hashCode = (_tt1 != null ? _tt1.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (_tt2 != null ? _tt2.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (_m11 != null ? _m11.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (_m12 != null ? _m12.GetHashCode() : 0);
                    return hashCode;
                }
            }
        }
    
        /// <summary>
        /// This is the cache used for compiled actions. Because compiling is time consuming, I think it is better to cache.
        /// </summary>
        private static readonly ConcurrentDictionary<Key, object> CompiledActionsCache = new ConcurrentDictionary<Key, object>();
    
        /// <summary>
        /// Main Function which does the swapping
        /// </summary>
        public static void Swap<TSource, TDestination, TPropertySource>(TSource source, TDestination destination, Expression<Func<TSource, TPropertySource>> first, Expression<Func<TDestination, TPropertySource>> second)
        {
            //Try to get value from the cache or if it is cache miss then use Factory method to create Compiled Action
            var swapper = (Action<TSource, TDestination>)CompiledActionsCache.GetOrAdd(GetKey(first, second), k => Factory(first, second));
            //Do the actual swapping.
            swapper(source, destination);
        }
    
        /// <summary>
        /// Our factory method which does all the heavy lfiting fo creating swapping actions.
        /// </summary>
        private static Action<TSource, TDestination> Factory<TSource, TDestination, TPropertySource>(Expression<Func<TSource, TPropertySource>> first, Expression<Func<TDestination, TPropertySource>> second)
        {
            //////////////This is our aim/////////////
            //// var temp = obj1.Property;       /////
            //// obj1.Property = obj2.Property;  /////
            //// obj2.Property = temp;           /////
            //////////////////////////////////////////
    
            // Temp value for required for swapping
            var tempValue = Expression.Variable(typeof(TPropertySource), "temp_value");
            // Expression assignment
            // first.body is already accesing property, just use it as it is :)
            var assignToTemp = Expression.Assign(tempValue, first.Body);
            // Expression assignment
            // second.body is already accesing property, just use it as it is :)
            var secondToFirst = Expression.Assign(first.Body, second.Body);
            // Final switch here
            var tempToSecond = Expression.Assign(second.Body, tempValue);
            // Define an expression block which has all the above assignments as expressions
            var blockExpression = Expression.Block(new[] { tempValue }, assignToTemp, secondToFirst, tempToSecond);
            // An expression itself is not going to swap values unless it is compiled into a delegate
            // (obj1, obj2) => blockExpression from the previous line 
            return Expression.Lambda<Action<TSource, TDestination>>(blockExpression, first.Parameters[0], second.Parameters[0]).Compile();
        }
    
        /// <summary>
        /// Key creator method.
        /// </summary>
        private static Key GetKey<TSource, TDestination, TPropertySource>(Expression<Func<TSource, TPropertySource>> first, Expression<Func<TDestination, TPropertySource>> second)
        {
            var sourceType = typeof(TSource);
            var destinationType = typeof(TDestination);
            var sourcePropertyInfo = ((MemberExpression)first.Body).Member;
            var destinationPorpertyInfo = ((MemberExpression)second.Body).Member;
            return new Key(sourceType, destinationType, sourcePropertyInfo, destinationPorpertyInfo);
        }
    }
