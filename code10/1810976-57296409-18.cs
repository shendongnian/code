    static class MatrixExtension
    {
        public static Vector<double>[] SolveDegenerate(this Matrix<double> matrix, Vector<double> input)
        {
            var augmentedMatrix =
                Matrix<double>.Build.DenseOfColumnVectors(matrix.EnumerateColumns().Append(input));
            if (augmentedMatrix.Rank() != matrix.Rank())
                throw new ArgumentException("Augmented matrix rank does not match coefficient matrix rank.");
            return augmentedMatrix.SolveAugmented();
        }
        private static Vector<double>[] SolveAugmented(this Matrix<double> matrix)
        {
            var rank = matrix.Rank();
            var cut = matrix.CutByRank(rank);
            // [A|R]x[X] = [B]            
            var A = Matrix<double>.Build.DenseOfColumnVectors(cut.EnumerateColumns().Take(rank));
            var R = Matrix<double>.Build.DenseOfColumnVectors(cut.EnumerateColumns().Skip(rank).Take(cut.ColumnCount - rank - 1));
            var B = cut.EnumerateColumns().Last();
            var vectors = Matrix<double>.Build.DenseDiagonal(R.ColumnCount, 1)
                .EnumerateColumns().ToArray();
            return vectors.Select(v => A.Solve(B - R * v))
                .Zip(vectors, (x, v) => Vector<double>.Build.DenseOfEnumerable(x.Concat(v)))
                .ToArray();
        }
        private static Matrix<double> CutByRank(this Matrix<double> matrix, int rank)
        {
            var result = Matrix<double>.Build.DenseOfMatrix(matrix);
            while (result.Rank() < result.RowCount)
                result = result.EnumerateRows()
                               .Select((r, index) => result.RemoveRow(index))
                               .FirstOrDefault(m => m.Rank() == rank);
            return result;
        }
    }
