    namespace Project1 {
    public class Class1 {
        static int Main(string[] args) {
            Foo a = new Foo();
            a.SetValue(4);
            Console.WriteLine(a.GetValue<int>());
            Foo b = new Foo();
            a.SetValue("String");
            Console.WriteLine(a.GetValue<string>());
            Console.ReadLine();
            return 0;
        }
    }
    class Foo {
        private object value; // watch out for boxing here!
        public void SetValue(object value) {
            this.value = value;
        }
        public T GetValue<T>() {
            object val = this.value;
            if (val == null) { return default(T); } // or throw if you prefer
            try {
                return (T)val;
            }
            catch (Exception) {
                return default(T);
                // cast failed, return default(T) or throw
            }
        }
    }
    }
