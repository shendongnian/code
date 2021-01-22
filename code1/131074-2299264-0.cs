      class SomeClass<T>
      {
         SomeClass()
         {
            bool IsIComparable = typeof(IComparable).IsAssignableFrom(typeof(T));
         }
      } 
