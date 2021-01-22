    Int32 GetRecordSize(Type recordType) {
      return recordType.GetFields().Select(fieldInfo => GetFieldSize(fieldInfo)).Sum();
    }
    
    Int32 GetFieldSize(FieldInfo fieldInfo) {
      if (fieldInfo.FieldType.IsArray) {
        // The size of an array is the size of the array elements multiplied by the
        // length of the array.
        var arraySizeAttribute = (ArraySizeAttribute) Attribute.GetCustomAttribute(fieldInfo, typeof(ArraySizeAttribute));
        if (arraySizeAttribute == null)
          throw new InvalidOperationException("Missing ArraySizeAttribute on array.");
        return GetTypeSize(fieldInfo.FieldType.GetElementType())*arraySizeAttribute.Length;
      }
      else
        return GetTypeSize(fieldInfo.FieldType);
    }
    
    Int32 GetTypeSize(Type type) {
      if (type == typeof(Int32))
        return 4;
      else if (type == typeof(Boolean))
        return 1;
      else
        throw new InvalidOperationException("Unexpected type.");
    }
