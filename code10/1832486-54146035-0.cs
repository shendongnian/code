    public sealed class MyEqualityComparer : IEqualityComparer<type1> {
      public bool Equals(type1 x, type1 y) {
        // Your method here
        return MyClass.CheckIfObjectsAreEquivalent(x, y);
      }
      public int GetHashCode(type1 obj) {
        //TODO: you have to implement HashCode as well
        // return 0; is the WORST possible implementation
        // However the code will do for ANY type (type1)
        return 0; 
      }
    }
