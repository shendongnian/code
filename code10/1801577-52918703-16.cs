    private Data[,] _matrix;
    public double[,] Matrix
    {
        get {
            var m = new double[LinhaText, ColunText];
            for (int row = 0; row < LinhaText; row++) {
                for (int col = 0; col < ColunText; col++) {
                    m[row, col] = _matrix[row, col].Value;
                }
            }
            return m;
        }
    }
