    public static void SafeForEach<T>(this IEnumerable<T> input,
                                           Action<T> action,
                                           Action<T, Exception> faultAction = null)
    {
        if (input == null || action == null)
            return;
        foreach (var item in input)
            try
            {
                action(item);
            }
            catch (Exception ex)
            {
                if (faultAction == null)
                    Debug.WriteLine(ex);
                else
                    faultAction(item, ex);
            }
    }
