    public static class ArrayExtensions
    {
      public static T[] SubArray<T>(this T[] array, int index, int length)
      {
        T[] result = new T[length];
    
        for (int i=index;i<length && i<array.Length;i++)
        {
           if (array[i] is ICloneable)
              result[i] = ((ICloneable)array[i]).Clone();
           else
              result[i] = CloneObject(array[i]);
        }
    
        return result;
      }
    
      private static object CloneObject(object obj)
      {
        BinaryFormatter formatter = new BinaryFormatter();
    
        using (MemoryStream stream = new MemoryStream())
        {
          formatter.Serialize(stream, obj);
          
          stream.Seek(0);
          
          return formatter.Deserialize(stream);
        }
      }
    }
