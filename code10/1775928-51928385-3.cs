    public static void RemoveAt<T>(arr, int index)
    {
        for (int a = index; a < arr.Length - 1; a++)
        {
            arr[a] = arr[a + 1];
        }
        var reference = arr;
        Array.Resize(ref reference, arr.Length - 1);
    }
