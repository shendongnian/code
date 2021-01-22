    using System;
    using System.Reflection;
    namespace test {
        class Test123<T> 
            where T : struct {
            public Nullable<T> Test { get; set; }
        }
        class Test321 {
            public Test123<int> Test { get; set; }
        }
        class Program {
            public static void Main() {
                Type test123Type = typeof(Test123<>);
                Type test123Type_int = test123Type.MakeGenericType(typeof(int));
                object test123_int = Activator.CreateInstance(test123Type_int);
                object test321 = Activator.CreateInstance(typeof(Test321));
                PropertyInfo test_prop = test321.GetType().GetProperty("Test");
                test_prop.GetSetMethod().Invoke(test321, new object[] { test123_int });
            }
        }
    }
