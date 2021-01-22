    public sealed class SecureAttribute : Attribute
    {
       ...
       public enum SecureFuncType
       {
          Type1,
          Type2,
          Type3
       }
       private static readonly Dictionary<SecureFuncType, Func<Product, bool>>
          sSecureFuncs = new Dictionary<SecureFuncType, Func<Product, bool>>
       {
          { Type1, role => role.CanDoThis && role.AllowedCount > 1 },
          { Type2, role => role.CanDoThis && role.AllowedCount > 2 },
          { Type3, role => role.CanDoThis && role.AllowedCount > 3 }
       }
    }
    ...
    using SecureFuncType = SecureAttribute.SecureFuncType;
    [Secure(SecureFuncType.Type1)]
    [Secure(SecureFuncType.Type2)]
    [Secure(SecureFuncType.Type3)]
    // etc...
