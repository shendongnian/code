    namespace System.Immutable {
      using System.Collections;
    
      public interface IImmutable { };
    
      public static partial class ExtensionMethods {
        public static bool ImmutableEquals<TSrc>(this TSrc inst, object obj, Func<TSrc, bool> f) where TSrc : IEquatable<TSrc>, IImmutable {
          if (object.ReferenceEquals(inst, obj)) return true; // same reference ->  equal
          if (obj is null) return false; // this is not null but obj is -> not equal
          if (!(obj is TSrc o)) return false; // obj cannot be cast to this type -> not equal
          if (obj.GetType() != inst.GetType()) return false; // obj is more derived than this -> not equal
          if (inst.GetHashCode() != o.GetHashCode()) return false; // optimization, hash codes are different -> not equal
          return f(o);
        }
    
        public static int ImmutableHash<TSrc>(this TSrc inst, ref int? hashCache, Func<IStructuralEquatable> f) where TSrc : IEquatable<TSrc>, IImmutable {
          if (hashCache is null) hashCache = f().GetHashCode();
          return hashCache.Value;
        }
      }
    }
