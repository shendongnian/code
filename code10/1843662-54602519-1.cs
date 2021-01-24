    public class Matrix<T> where T : new()
    {
       public T[][] matrix;
       public Matrix(int x, int y)
          => matrix = Enumerable.Range(0,x).Select(elem => new T[y]).ToArray();    
    }
