    public class Matrix<T>
    {
       List<List<T>> matrix;
    
       public void Add(IEnumerable<T> row)
       {
          List<T> newRow = new List<T>(row);
          matrix.Add(newRow);
       }
    
       public T this[int x, int y]
       {
          get  { return matrix[y][x]; }
       }
       ....
    }
