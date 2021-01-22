     static class Extension
     {
        public static void ConstructArray<T>(this T[] objArray) where T : new()
        {
            for (int i = 0; i < objArray.Length; i++)
                objArray[i] = new T();
        }
    }
