    class Matrix
    {
        public readonly int[] BigArray;   // make available
        private int _rowSize = ...;
       
        public int this[int x, int y]
        {
           get { return BigArray [x*_rowSize+y]; }
           set { BigArray [x*_rowSize+y] = value; }
        }
    }
