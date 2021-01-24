    static int[] Func(int[] array1, int[] array2)
    {
        int[] result = new int[array1.Length + array2.Lenght];
        
        Array.Copy(array1, result, array1.Length);
        Array.Copy(array2, 0, result, array1.Length, array2.Length);
        Array.Sort(result);
        return result;
    }
