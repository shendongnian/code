    class INumericOps<T> {
      public abstract T One { get; }
      public abstract T Add(T a, T b); 
      // and other operations that you may need
    }
    // Implementations of numeric operations for decimal and double
    class DecimalNumerics : INumericOps<decimal> { ... }
    class DoubleNumerics : INumericOps<double> { ... }
