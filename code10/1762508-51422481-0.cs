    public interface IA {
    }
    public class A : IA {
      IC _c;
      public A(IC c) {
        _c = c;
      }
    }
    public interface IB {
    }
    public class B : IB {
      IA _a;
      IC _c;
      public B(IA a, IC c) {
        _a = a;
        _c = c;
      }
    }
    public interface IC {
    }
    public class C : IC {
    }
