    public class Matrix<T> 
    {    
        public T[,] matrix;
    
        public Matrix<T>(int x, int y)
        {
            matrix = new T[x, y];
        }
    }
