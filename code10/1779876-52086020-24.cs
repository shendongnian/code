    public static IEnumerable<(int index, int value)> FindDuplicates(int[] A)
    {
        for (int i = 0; i < A.Length; i++) {
            int x = A[i] % A.Length;
            if (A[x] >= 0) {
                if (A[x] < A.Length) { // First occurrence.
                    A[x] += (i + 1) * A.Length; // Encode the first index.
                } else { // Second occurrence.
                    int firstIndex = (A[x] / A.Length) - 1; // Decode the first index.
                    yield return (firstIndex, x);
                    // Mark the value as handeled by making it negative;
                    A[x] *= -1; // A[x] is always >= A.Length, so no zero problem.
                }
            }
        }
    }
