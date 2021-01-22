    static public class Decorators
    {
        static Dictionary<object,Dictionary<Type,object>> instance = new Dictionary<object,Dictionary<Type,object>>();
        public static void AddDecorator<T,D>(this T obj, D decor)
        {
            Dictionary<Type,object> d;
            if (!instance.TryGetValue(obj, out d))
            {
                d = new Dictionary<Type,object>();       
                instance.Add(obj, d);
            }
            d[typeof(D)]=decor;
        }
        public static D GetDecorator<T,D>(this T obj)
        {
            // here must be double TryGetValue, but I leave it to you to add it  
            return (D) instance[obj][typeof(D)];
        }
        public static T ClearDecorators(this T obj) { instance.remove(obj); }
        
    }
    // Decorator<T> code stays the same, but without type constraint
    
