    public static class Extenders
    {
        public static T[] FillWith<T>( this T[] array, T value )
        {
            for(int i = 0; i < array.Length; i++)
            {
                array[i] = value;
            }
            return array;
        }
    }
    
    // now you can do this...
    int[] array = new int[100];
    array.FillWith( 42 );
