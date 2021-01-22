    public static void PointyMethod(char[] array)
    {
        unsafe
        {
            fixed (char *p = array)
            {
                for (int i=0; i<array.Length; i++)
                {
                    System.Console.Write(*(p+i));
                }
            }
        }
    }
