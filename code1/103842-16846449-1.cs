    sealed class Product {
       public bool CanDoThis { get; set; }
       public int AllowedCount { get; set; }
    }
    public enum SecureFuncType {
       Type1,
       Type2,
       Type3
    }
    sealed class SecureAttribute : Attribute {
       [NotNull] readonly Func<Product, bool> mFunc;
       public SecureAttribute(SecureFuncType pType) {
          var secureFuncs = new Dictionary<SecureFuncType, Func<Product, bool>> {
             { SecureFuncType.Type1, role => role.CanDoThis && role.AllowedCount > 1 },
             { SecureFuncType.Type2, role => role.CanDoThis && role.AllowedCount > 2 },
             { SecureFuncType.Type3, role => role.CanDoThis && role.AllowedCount > 3 }
          };
          mFunc = secureFuncs[pType];
       }
    }
