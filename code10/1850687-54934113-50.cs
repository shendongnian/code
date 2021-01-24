    namespace System.Immutable {
      public interface IImmutableEquatable<T> : IEquatable<T> { };
    
      public static partial class ExtensionMethods {
        public static bool Equals<T>(this T inst, object obj, Func<T, bool> thisEquals) where T : IImmutableEquatable<T> =>
          object.ReferenceEquals(inst, obj) // same reference ->  equal
          || !(obj is null) // this is not null but obj is -> not equal
          && obj.GetType() == inst.GetType() // obj is more derived than this -> not equal
          && inst.GetHashCode() == obj.GetHashCode() // optimization, hash codes are different -> not equal
          && obj is T o // obj cannot be cast to this type -> not equal
          && thisEquals(o);
    
        public static int GetHashCode<T>(this T inst, ref int? hashCache, Func<int> thisHashCode) where T : IImmutableEquatable<T> {
          if (hashCache is null) hashCache = thisHashCode();
          return hashCache.Value;
        }
      }
    }
