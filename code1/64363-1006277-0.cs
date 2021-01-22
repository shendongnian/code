    class Foo {
        public string abc;
    }
    class Bar : Foo {
        private int def;
    }
    static class Program {
        static void Main() {
            object obj = new Bar();
            FieldInfo[] fields = obj.GetType().GetFields(
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
    
            foreach(FieldInfo field in fields) {
                Console.WriteLine(field.Name + " = " + field.GetValue(obj));
            }
        }
    }
