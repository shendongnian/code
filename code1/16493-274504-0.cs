    using System.Diagnostics;
    public class ArrayExtractor
    {
      public static void Extract<T1>(object[] array, out T1 value1)
          where T1 : class
      {
        Debug.Assert(array.Length >= 1);
        value1 = array[0] as T1;
      }
      public static void Extract<T1, T2>(object[] array, out T1 value1, out T2 value2)
          where T1 : class
          where T2 : class
      {
        Debug.Assert(array.Length >= 2);
        value1 = array[0] as T1;
        value2 = array[1] as T2;
      }
    }
