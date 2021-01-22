     public Matrix(int width, int height) : this(width, height, default(T)) {}
     public Matrix(int width, int height, T defaultValue)
     {
         List<T> rows = new List<T>(height);
         for (int i = 0; i < height; i++)
         {
             List<T> columns = new List<T>(width);
             for (int j = 0; j < width; j++)
             { columns.Add(defaultValue); }
             rows.Add(column);
         }
         // store `rows` wherever you are storing it internally.
     }
