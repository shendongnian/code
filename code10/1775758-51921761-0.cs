    public class Grid<T> {
            T[,] grid { get; }
            int FindIndex(int provided) {
                return provided + grid.GetLength(0) / 2;
            }
            public Grid(int dimension) {
                if (dimension % 2 != 0)
                    throw new ArgumentException("Grid must be evenly divisible");
                grid = new T[dimension, dimension];
            }
            public T this[int key, int key2] {
                get {
                    return grid[FindIndex(key), FindIndex(key2)];
                }
                set {
                    grid[FindIndex(key), FindIndex(key2)] = value;
                }
            }
        }
