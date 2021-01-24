    public static IEnumerable<(int index, int value)> FindDuplicates(int[] A)
    {
        for (int i = 0; i < A.Length; i++) {
            int x = A[i] % A.Length;
            if (A[x] / A.Length == 1) {
                yield return (i, x);
            }
            A[x] += A.Length;
        }
    }
