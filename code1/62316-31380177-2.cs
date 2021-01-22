    //requres a reference to Microsoft.CSharp.dll
    using Microsoft.CSharp.RuntimeBinder; 
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    public static class TypeCastHelper
    {
        private static Type CastType = typeof(CastClass<>);
        private static Dictionary<Type, Func<object, object>> Cache 
            = new Dictionary<Type, Func<object, object>>();
        private static class CastClass<T>
        {
            private static CallSite<Func<CallSite, object, T>> Site;
            static CastClass()
            {
                Site = CallSite<Func<CallSite, object, T>>
                    .Create(Microsoft.CSharp.RuntimeBinder.Binder
                    .Convert(CSharpBinderFlags.ConvertExplicit,
                    typeof(T), CastType));
            }
            public static object Cast(object o)
            {
                try
                {
                    return Site.Target.Invoke(Site, o);
                }
                catch (RuntimeBinderException e)
                {
                    throw new InvalidCastException(e.Message);
                }
            }
        }
        private static Func<object, object> MakeCastDelegate(Type t)
        {
            return (Func<object, object>)CastType.MakeGenericType(t)
                .GetMethod("Cast")
                .CreateDelegate(typeof(Func<object, object>));
        }
        public static Func<object, object> GetCastDelegate(Type t)
        {
            Func<object, object> d;
            if (!Cache.TryGetValue(t, out d))
            {
                d = MakeCastDelegate(t);
                Cache.Add(t, d);
            }
            return d;
        }
        public static object Cast(object o, Type t)
        {
            return GetCastDelegate(t).Invoke(o);
        }
    }
