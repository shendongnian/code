    // Notice the ref.
    private static void DeleteElement(ref int[] list, int index)
    {
        for (int i = index; i < list.Length - 1; i++)
        {
            list[i] = list[i + 1];
        }
        // This step removes the last element from the array.
        Array.Resize(ref list, list.Length - 1);
    }
