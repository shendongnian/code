    public class Reference<T>
    {
      private readonly Func<T> referenceFunc;
      
      public Reference(Func<T> referenceFunc)
      {
        this.referenceFunc = referenceFunc;
      }
      
      public T Value => this.referenceFunc();
      
      public static implicit operator T(Reference<T> reference)
      {
        return reference.Value;
      }
      
      public static implicit operator Reference<T>(Func<T> referenceFunc)
      {
        return new Reference<T>(referenceFunc);
      }
      
      public override string ToString()
      {
        return this.Value?.ToString();
      }
    }
    public static class ReferenceExtensions
    {
      public static void Add<T>(
          this ICollection<Reference<T>> collection,
          Func<T> referenceFunc)
      {
        collection.Add(referenceFunc);
      }
    }
