    public static void RotateLeft<T>(T[] array, int places)
    {
        T[] temp = new T[places];
        Array.Copy(array, 0, temp, 0, places);
        Array.Copy(array, places, array, 0, array.Length - places);
        Array.Copy(temp, 0, array, array.Length - places, places);
    }
