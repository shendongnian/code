    public class CastTo {
        protected static class Cache<TTo, TFrom> {
            public static readonly Func<TFrom, TTo> Caster = Get();
            static Func<TFrom, TTo> Get() {
                var p = Expression.Parameter(typeof(TFrom), "from");
                var c = Expression.ConvertChecked(p, typeof(TTo));
                return Expression.Lambda<Func<TFrom, TTo>>(c, p).Compile();
            }
        }
    }
    public class ValueCastTo<TTo> : ValueCastTo {
        public static TTo From<TFrom>(TFrom from) {
            return Cache<TTo, TFrom>.Caster(from);
        }
    }
