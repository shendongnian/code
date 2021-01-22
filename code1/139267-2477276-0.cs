    private static void SaveOrRemove<T>(string key, Nullable<T> value)
    {
        if (!value.HasValue()) // is null
        {
            Console.WriteLine("Remove: " + key);
        }
        else
        {
            T val = value.Value;
            // ...
        }
    }
