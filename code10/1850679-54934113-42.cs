    namespace System.Immutable {
    
      public interface IImmutable<T> {
        bool _Equals(T o);
        int _GetHashCode();
      };
    
      public static partial class ExtensionMethods {
        public static bool ImmutableEquals<T>(this T inst, object obj) where T : IEquatable<T>, IImmutable<T> =>
          object.ReferenceEquals(inst, obj) // same reference ->  equal
	      || !(obj is null) // this is not null but obj is -> not equal
          && obj.GetType() == inst.GetType() // obj is more derived than this -> not equal
          && inst.GetHashCode() == obj.GetHashCode() // optimization, hash codes are different -> not equal
          && obj is T o // obj cannot be cast to this type -> not equal
          && inst._Equals(o);
    
        public static int ImmutableHash<T>(this T inst, ref int? hashCache) where T : IEquatable<T>, IImmutable<T> {
          if (hashCache is null) hashCache = inst._GetHashCode();
          return hashCache.Value;
        }
      }
    }
