        public static class ExtensionMethods_Object
        {                
            [DebuggerStepThrough()]
            public static bool Is<T>(this object item) where T : class
            {
                return item is T;
            }
    
            [DebuggerStepThrough()]
            public static bool IsNot<T>(this object item) where T : class
            {
                return !(item.Is<T>());
            }
    
            [DebuggerStepThrough()]
            public static T As<T>(this object item) where T : class
            {
                return item as T;
            }
        }
