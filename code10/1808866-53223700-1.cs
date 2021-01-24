    public static void AddWithCheck<T>(this List<T> list, T value)
    {
      if (value != null)
        list.Add(value);
    }
