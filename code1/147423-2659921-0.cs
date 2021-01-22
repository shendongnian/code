    class Bar {
        new Type GetType() { return null; }
    }
    static class Program {
        static void Main() {
            var methods = typeof(Bar).GetMethods(
                  BindingFlags.Instance | BindingFlags.Static
                | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (var method in methods) {
                Console.WriteLine(method.Name);
            }
        }
    }
