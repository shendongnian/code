    interface I<T> {
      T M(T p);
    }
    abstract class A<T> : I<T> {
      public abstract T M(T p);
    }
    abstract class B<T> : A<T>, I<int> {
      public override T M(T p) { return p; }
      public int M(int p) { return p * 2; }
    }
    class C : B<int> { }
  
    class Program {
      static void Main(string[] args) {
        Console.WriteLine(new C().M(42));
      }
    }
