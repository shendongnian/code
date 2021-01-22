    public static class ArrayExtensions
    {
      public static T[] SubArray<T>(this T[] array, int index, int length)
      {
        T[] result = new T[length];
    
        for (int i=index;i<length && i<array.Length;i++)
        {
           if (array[i] is ICloneable)
              result[i] = (T) ((ICloneable)array[i]).Clone();
           else
              result[i] = (T) CloneObject(array[i]);
        }
    
        return result;
      }
    
      private static object CloneObject(object obj)
      {
        BinaryFormatter formatter = new BinaryFormatter();
    
        using (MemoryStream stream = new MemoryStream())
        {
          formatter.Serialize(stream, obj);
          
          stream.Seek(0,SeekOrigin.Begin);
          
          return formatter.Deserialize(stream);
        }
      }
    }
