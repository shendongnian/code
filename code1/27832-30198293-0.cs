    struct Mutable {
    public int x;
    }
    class Test {
        private Mutable m = new Mutable();
        public int mutate()
        { 
            m.x = m.x + 1;
            return m.x;
        }
      }
      static void Main(string[] args) {
            Test t = new Test();
            System.Console.WriteLine(t.mutate());
            System.Console.WriteLine(t.mutate());
            System.Console.WriteLine(t.mutate());
        }
