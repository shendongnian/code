    public static IEnumerable<int> TryCastToInt<T>(this IEnumerable<T> values)
      int num = 0;
      foreach (object item in values) {
        if (Int32.TryParse(item.ToString(), num)) {
          yield return num;
        }
      }
    }
