    public Matrix {
      private Dictionary<string, double> matrixData; // Matrix indecies, value
      public double this[int row, int col] {
        get {
          return matrixData[string.Format("{0},{1}", row, col)];
        }
      }
    }
