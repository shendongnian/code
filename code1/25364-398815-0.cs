    namespace MyNameSpace
    {
      public interface Cars
      {
        public void Drive(int miles);
      }
      public class Honda : Cars
      {
        public void Drive(int miles) { ... }
      }
      public class Toyota : Cars
      {
        public void Drive(int miles) { ... }
      }
    }
