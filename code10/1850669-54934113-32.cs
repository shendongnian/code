    namespace System.Immutable {
    
      public interface IImmutable<TSrc> {
        bool ValueEquals(TSrc o);
        int ValueHashCode();
      };
    
      public static partial class ExtensionMethods {
        public static bool ImmutableEquals<TSrc>(this TSrc inst, object obj) where TSrc : IEquatable<TSrc>, IImmutable<TSrc> {
          if (object.ReferenceEquals(inst, obj)) return true; // same reference ->  equal
          if (obj is null) return false; // this is not null but obj is -> not equal
          if (obj.GetType() != inst.GetType()) return false; // obj is more derived than this -> not equal
          if (inst.GetHashCode() != obj.GetHashCode()) return false; // optimization, hash codes are different -> not equal
          if (!(obj is TSrc o)) return false; // obj cannot be cast to this type -> not equal
          return inst.ValueEquals(o);
        }
    
        public static int ImmutableHash<TSrc>(this TSrc inst, ref int? hashCache) where TSrc : IEquatable<TSrc>, IImmutable<TSrc> {
          if (hashCache is null) hashCache = inst.ValueHashCode();
          return hashCache.Value;
        }
      }
    }
