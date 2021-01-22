    static class ObjectExtensions {
        public static object GetObjectPropertyValue(this object o, string propertyName) {
            return o.GetType().GetProperty(propertyName).GetValue(o, null);
        }
    }
    class Test {
        public string Message {get; set;}
    }
    class Program {
        static void Main(string[] args) {
            object t = new Test { Message = "Hello, World!" };
            Console.WriteLine(t.GetObjectPropertyValue("Message").ToString());
        }
    }
