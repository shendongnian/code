    public static class MyExtensions
    {
        public static string[] GetArray(this string[,] table, int dimension )
        {
            string[] array = new string[table.GetLength(dimension)];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = table[dimension, i];
            }
            return array;
        }
    }
