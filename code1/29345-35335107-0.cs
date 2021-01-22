    class Program {
        static void Main(string[] args) {
            List<int> c = new List<int>(); 
            double i = 10.0;
            Type intType = typeof(int);
            c.Add(CastHelper.Cast(i, intType)); // works, no exception!
        }
    }
    class CastHelper {
        public static dynamic Cast(object src, Type t) {
            var castMethod = typeof(CastHelper).GetMethod("CastGeneric").MakeGenericMethod(t);
            return castMethod.Invoke(null, new[] { src });
        }
        public static T CastGeneric<T>(object src) {
            return (T)Convert.ChangeType(src, typeof(T));
        }
    }
