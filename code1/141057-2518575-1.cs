      public static T[] GetPreFilledArray<T>(T fillItem, int count)
      {
           var result = new T[count];
           for(int i =0; i < count; i++)
           {
               result[i] = fillItem;
           }
           return result;
      }
      byte[] byteArray = GetPreFilledArray((byte)0xFF, 1000);
