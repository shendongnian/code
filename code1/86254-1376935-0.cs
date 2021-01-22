    public static readonly ReadOnlyThreeDimensions<int> MyGlobalThree 
        = new ReadOnlyThreeDimensions<int>(IntInitializer);
    public class ReadOnlyThreeDimensions<T> 
    {
        private T[][][] _arrayOfT;
        public ReadOnlyThreeDimensions(Func<T[][][]> initializer)
        {
            _arrayOfT = initializer();
        }
        public ReadOnlyThreeDimensions(T[][][] arrayOfT)
        {
            _arrayOfT = arrayOfT;
        }
        public T this [int x, int y, int z]
        {
            get 
            {
                return _arrayOfT[x][y][z];
            } 
        }
    }
