    using System;
    static class Utils {
        public static T GetProperty<T>(this object obj, string name) {
            var property = obj.GetType().GetProperty(name);
            if (null == property || !property.CanRead) {
                throw new ArgumentException("Invalid property name");
            }
            return (T)property.GetGetMethod().Invoke(obj, new object[] { });
        }
    }
    class X {
        public string A { get; set; }
        public int B { get; set; }
    }
    class Program {
        static void Main(string[] args) {
            X x = new X() { A = "test", B = 3 };
            string a = x.GetProperty<string>("A");
            int b = x.GetProperty<int>("B");
        }
    }
