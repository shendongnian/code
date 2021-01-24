    public class Grid<T> {
            T[,] grid { get; }
            int adjustment { get;}
            int FindIndex(int provided) {
                return provided + adjustment;
            }
            public Grid(int dimension) {
                if (dimension % 2 != 0)
                    throw new ArgumentException("Grid must be evenly divisible");
                adjustment = dimension / 2;
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
