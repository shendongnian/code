    namespace System.Immutable {
    
      public interface IImmutable<TSrc> {
        bool _Equals(TSrc o);
        int _GetHashCode();
      };
    
      public static partial class ExtensionMethods {
        public static bool ImmutableEquals<TSrc>(this TSrc inst, object obj) where TSrc : IEquatable<TSrc>, IImmutable<TSrc> =>
          object.ReferenceEquals(inst, obj) // same reference ->  equal
	      || !(obj is null) // this is not null but obj is -> not equal
          && obj.GetType() == inst.GetType() // obj is more derived than this -> not equal
          && inst.GetHashCode() == obj.GetHashCode() // optimization, hash codes are different -> not equal
          && obj is TSrc o // obj cannot be cast to this type -> not equal
          && inst._Equals(o);
    
        public static int ImmutableHash<TSrc>(this TSrc inst, ref int? hashCache) where TSrc : IEquatable<TSrc>, IImmutable<TSrc> {
          if (hashCache is null) hashCache = inst._GetHashCode();
          return hashCache.Value;
        }
      }
    }
