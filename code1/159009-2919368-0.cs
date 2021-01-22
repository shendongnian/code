        public static bool enericFunction2<T>(T a1, T a2) where T : class
        {
            object aa = a1;
            CustomClass obj1 = (CustomClass)aa;
            object bb = a2;
            CustomClass obj2 = (CustomClass)bb;
            return obj1 == obj2; 
        }
 
