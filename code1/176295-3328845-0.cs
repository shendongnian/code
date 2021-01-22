    public static class ArrayExtensions
    {
      T[] SubArray<T>(this T[] arr, int startIndex,int count)
      {
        var sub = new T[count];
        Array.Copy(arr,startIndex,sub,o,count);
        return sub;
      }
    }
