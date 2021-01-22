    using System;
    using System.Reflection;
    using System.Collections.Generic;
    
    class Test
    {
        public static List<object> ConvertToListOfObjects<T>(List<T> list)
        {
            return list.ConvertAll<object>(t => t);
        }
        
        static void Main()
        {
            object list = new List<int> { 1, 2, 3, 4 };
            
            MethodInfo method = typeof(Test).GetMethod("ConvertToListOfObjects",
                BindingFlags.Static | BindingFlags.Public);
            Type listType = list.GetType().GetGenericArguments()[0];
            MethodInfo concrete = method.MakeGenericMethod(new [] { listType });
            List<object> objectList = (List<object>) concrete.Invoke(null,
                                                        new object[] {list});
            
            foreach (object o in objectList)
            {
                Console.WriteLine(o);
            }
        }
    }
