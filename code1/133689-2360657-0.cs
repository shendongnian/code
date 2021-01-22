    // Represents either a value of type T or a value of type U
    class Either<T, U> { 
      public bool TryGetFirst(out T val);
      public bool TryGetSecond(out U val);
    }
    // For constructing values of type Either<T, U>
    static class Either {
      public static Either<T, U> First<T, U>(T val);
      public static Either<T, U> Second<T, U>(U val);
    }
