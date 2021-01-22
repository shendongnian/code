    IEnumerable<Point> GetPoints(Matrix matrix, int[] indexes)
    {
        if (indexes.Length == matrix.Rank)
        {
            yield return matrix.GetValue(indexes);
        }
        else
        {
            for (int i = 0; i < matrix.GetRankSize(indexes.Length); i++)
            {
                foreach (var point in
                    GetPoints(matrix, indexes.Concat(new int[] { i }).ToArray())
                {
                    yield return point;
                }
            }
        }
    }
