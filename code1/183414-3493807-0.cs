    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    sealed class ArraySizeAttribute : Attribute {
    
      public ArraySizeAttribute(Int32 length) {
        Length = length;
      }
    
      public Int32 Length { get; private set; }
    
    }
