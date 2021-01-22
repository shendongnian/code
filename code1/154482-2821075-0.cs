    using System;
    using System.Runtime.CompilerServices;
    
    public class Program {
      static void Main() {
        Console.Write(Verify(Test.Create()));
        Console.ReadLine();
      }
      //[MethodImpl(MethodImplOptions.NoInlining)]
      static bool Verify(IDisposable item) {
        return item is Test;
      }
      struct Test : IDisposable {
        public void Dispose() { }
        public static Test Create() { return new Test(); }
      }
    }
