    static class Ext {
    
        public static TypeofTypeofBar GetGraphTypeFromDotNetType(this Context ctx, Type t) {
           return __something(t);
        }
    
        public static void SubscribeTo<F, E>(this Type type, Context ctx, E e)
            where E: Event<T> {
            context.GetGraphTypeFromDotNetType(type).Subscribe<F>(a);
        }
    
    }
...
    typeof(Bar).SubscribeTo(context, action);
