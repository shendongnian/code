    static void Main(string[] args)
            {
                int[] array = {0, 1, 2, 3, 4, 5, 6, 7};
                Array.ConstrainedCopy(array, 1, array, 0, array.Length - 1);
                array[array.Length - 1] = 0;
            }
