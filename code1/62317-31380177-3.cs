Here is my method to cast an object but not to a generic type variable, rather to a System.Type dynamically:  
I create a lambda expression at run-time using System.Linq.Expressions, of type `Func<object, object>`, that unboxes its input, performs the desired type conversion then gives the result boxed. A new one is needed not only for all types that get casted to, but also for the types that get casted (because of the unboxing step). Creating these expressions is highly time consuming, because of the reflection, the compilation and the dynamic method building that is done under the hood. Luckily once created, the expressions can be invoked repeatedly and without high overhead, so I cache each one.
    private static Func<object, object> MakeCastDelegate(Type from, Type to)
    {
        var p = Expression.Parameter(typeof(object)); //do not inline
        return Expression.Lambda<Func<object, object>>(
            Expression.Convert(Expression.ConvertChecked(Expression.Convert(p, from), to), typeof(object)),
            p).Compile();
    }
    private static readonly Dictionary<Tuple<Type, Type>, Func<object, object>> CastCache
    = new Dictionary<Tuple<Type, Type>, Func<object, object>>();
    public static Func<object, object> GetCastDelegate(Type from, Type to)
    {
        lock (CastCache)
        {
            var key = new Tuple<Type, Type>(from, to);
            Func<object, object> cast_delegate;
            if (!CastCache.TryGetValue(key, out cast_delegate))
            {
                cast_delegate = MakeCastDelegate(from, to);
                CastCache.Add(key, cast_delegate);
            }
            return cast_delegate;
        }
    }
    public static object Cast(Type t, object o)
    {
        return GetCastDelegate(o.GetType(), t).Invoke(o);
    }
