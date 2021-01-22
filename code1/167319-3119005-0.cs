    static class Ext {
    
        public static TypeofTypeofBar GetGraphTypeFromDotNetType(this Context ctx, Type t) {
           return __something(t);
        }
    
        public static void SubscribeTo<F, X, Y>(this Type type, context ctx, Action<X,Y> a) {
            context.GetGraphTypeFromDotNetType(type).Subscribe<F>(a);
        }
    
    }
...
    typeof(Bar).SubscribeTo(context, action);
