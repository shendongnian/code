    static void Main(string[] args) {
            using (var c = new MyClass()) {
                Console.WriteLine("some work");
                throw new Exception("Exception");
                Console.WriteLine("Hello World!");
            }
        }
