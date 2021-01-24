      public interface IReadOnlyValue {
        int Value { get; }
      }
    
      // It seems that IValue should have both "get" and "set"
      // See IList<T> and IReadOnlyList<T> as an example
      // However, you can drop "get" if you want
      public interface IValue {
        int Value { get; set; }
      }
    
      public class MyValue: IReadOnlyValue, IValue {
        public int Value { get; set; }
      }
