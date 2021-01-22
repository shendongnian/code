    static void Main(string[] args) {
       try {
          Foo(1);
       } catch {
          Console.WriteLine("catch");
       } finally {
          Console.WriteLine("finally");
       }
    }
    public static int Foo(int i) {
       return Foo(i + 1);
    }
