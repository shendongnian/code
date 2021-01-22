    using System;
    using System.Reflection;
    namespace test {
        [AttributeUsage(AttributeTargets.Method)]
        public class AAttribute : Attribute {
            public AAttribute(Type type,string method) {
                MethodInfo mi = type.GetMethod(method);
            }
        }
        public class B {
            [A(typeof(B),"BMethod1")]
            public void BMethod1() {
            }
        }
    }
