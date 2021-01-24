 	 public static void FastReverse(this ValueType[] arr)
    {
        for (int i = 0; i < arr.Length / 2; i++)
        {
            ValueType tmp = arr[i];
            arr[i] = arr[arr.Length - i - 1];
            arr[arr.Length - i - 1] = tmp;
        }
    }
    // usage:
    int[] a = {1,2,3};
    a.FastReverse(); // Can't find this method!
