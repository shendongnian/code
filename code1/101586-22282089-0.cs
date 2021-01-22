    public static void Main(string[] args) {
        for (dynamic x = 0, y = new MyClass { a = 20, b = 30 }; x < 100; x++, y.a++, y.b--) {
            Console.Write("X=" + x + " (" + x.GetType() + "\n" +
                          "Y.a=" + y.a + ",Y.b=" + y.b + " (" + y.GetType() + "\n");
         }
    }
        
    class MyClass {
        public int a = 0, b = 0;
    }
