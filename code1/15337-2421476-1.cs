        public static class Static<T> where T : new()
        {
          public static T Value = new T();
        }
    
        public interface ISumable<T>
        {
          T Add(T left, T right);
        }
        
        public T Aggregate<T>(T left, T right) where T : ISumable<T>, new()
        {
          return Static<T>.Value.Add(left, right);
        }
