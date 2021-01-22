    using System;
    using System.Reflection;
    namespace test {
        [AttributeUsage(AttributeTargets.Method)]
        public class AAttribute : Attribute {
            public static void CheckType<T>() {
                foreach (MethodInfo mi in typeof(T).GetMethods()) {
                    AAttribute[] attributes = (AAttribute[])mi.GetCustomAttributes(typeof(AAttribute), false);
                    if (0 != attributes.Length) {
                        // do your checks here
                    }
                }
            }
        }
        public class B {
            [A]
            public void BMethod1() {
            }
            [A]
            public int BMethod2() {
                return 0;
            }
        }
        public static class Program {
            public static void Main() {
                AAttribute.CheckType<B>();
            }
        }
    }
