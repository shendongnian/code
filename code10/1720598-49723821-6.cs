    public class Packed3dArray : IEnumerable<int>
    {
        readonly int width, height, hig;
        readonly int[] array;
        public Packed3dArray(int[] array, int mm)
        {
            int offset = (mm - 1) % 3;
            this.width = offset == 0 ? 4 : 8;
            this.height = offset == 1 ? 4 : 8;
            this.hig = offset == 2 ? 4 : 8;
            this.array = array;
        }
        #region Properties
        public int Width => width;
        public int Height => height;
        public int Hig => hig;
        public int Index(int row, int col, int wid) => wid + hig*(col + height*row);
        
        /// <summary>
        /// Default indexer. 
        /// </summary>
        public int this[int row, int col, int wid]
        {
            // this is really fast because it is integer math
            // and accesses a 1D array which is recommended.
            get => array[wid + hig*(col + height*row)];
            set => array[wid + hig*(col + height*row)] = value;
        }
        #endregion
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < array.Length; i++)
            {
                yield return array[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
