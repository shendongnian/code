    using System;
    using System.Collections.Generic;
    static class Program {
        static Type GetListType(Type type) {
            foreach (Type intType in type.GetInterfaces()) {
                if (intType.IsGenericType
                    && intType.GetGenericTypeDefinition() == typeof(IList<>)) {
                    return intType.GetGenericArguments()[0];
                }
            }
            return null;
        }
        static void Main() {
            object o = new List<int> { 1, 2, 3, 4, 5 };
            Type t = o.GetType();
            Type lt = GetListType(t);
            if (lt != null) {
                typeof(Program).GetMethod("StringifyList")
                    .MakeGenericMethod(lt).Invoke(null,
                    new object[] { o });
            }
        }
        public static void StringifyList<T>(IList<T> list) {
            Console.WriteLine("Working with " + typeof(T).Name);
        }
    }
