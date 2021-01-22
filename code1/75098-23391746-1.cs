    /// <summary>
    /// Class to cast to type <see cref="T"/>
    /// </summary>
    /// <typeparam name="T">Target type</typeparam>
    public static class CastTo<T>
    {
        /// <summary>
        /// Casts <see cref="S"/> to <see cref="T"/>. 
        /// This does not cause boxing for value types. 
        /// Useful in generic methods
        /// </summary>
        /// <typeparam name="S">Source type to cast from. Usually a generic type.</typeparam>
        public static T From<S>(S s)
        {
            return Cache<S>.caster(s);
        }    
    
        static class Cache<S>
        {
            internal static readonly Func<S, T> caster = Get();
            
            static Func<S, T> Get()
            {
                var p = Expression.Parameter(typeof(S));
                var c = Expression.ConvertChecked(p, typeof(T));
                return Expression.Lambda<Func<S, T>>(c, p).Compile();
            }
        }
    }
