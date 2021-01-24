    public static IEnumerable<int> FindDuplicates(int[] A)
    {
        for (int i = 0; i < A.Length; i++) {
            int absAi = Math.Abs(A[i]);
            if (A[absAi] < 0) {
                yield return absAi;
            } else {
                A[absAi] *= -1;
            }
        }
    }
