    public interface IMatrix<T>
    {
    	int Rows { get; }
    	int Columns { get; }
    	ref T this[int row, int column] { get; }
    }
