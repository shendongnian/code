        /// <summary>
        /// Create an empty jagged array of rows×cols
        /// </summary>
        public static T[][] CreateJaggedArray<T>(int rows, int cols)
        {
            var matrix=new T[rows][];
            for(int i=0; i<rows; i++)
            {
                matrix[i]=new T[cols];
            }
            return matrix;
        }
        /// <summary>
        /// Create a jagged array of rows×cols, and populate it with values row by row.
        /// </summary>
        public static T[][] CreateJaggedArray<T>(int rows, int cols, params T[] elements)
        {
            var matrix=new T[rows][];
            for(int i=0, k=0; i<rows; i++, k+=cols)
            {
                var row=new T[cols];
                Array.Copy(elements, k, row, 0, cols);
                matrix[i]=row;
            }
            return matrix;
        }
        /// <summary>
        /// Create a jagged array of rows×cols and populate it with a function like <c>(i,j)=> i==j ? 1 : 0</c>
        /// </summary>
        public static T[][] CreateJaggedArray<T>(int rows, int cols, Func<int, int, T> init)
        {
            var matrix=new T[rows][];
            for(int i=0, k=0; i<rows; i++, k+=cols)
            {
                var row=new T[cols];
                for(int j=0; j<cols; j++)
                {
                    row[j]=init(i, j);
                }
                matrix[i]=row;
            }
            return matrix;
        }
