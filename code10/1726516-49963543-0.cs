    public static bool IsSortedAscending(string[] arr)
    {
        for (int i = arr.Length - 2; i >= 0; i--)
        {
            // Fail if this ID is equal to or bigger than the next one.
            if (arr[i].CompareTo(arr[i + 1]) >= 0)
            {
                return false;
            }
        }
        return true;
    }
