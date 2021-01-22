    static void SetValue2(this Array a, object value, int i) {
        int[] indices = new int[a.Rank];
        for (int d = 0; d < a.Rank; d++) {
            var l = a.GetLength(d);
            indices[d] = i % l;
            i /= a.GetLength(d);
        }
        a.SetValue(value, indices);
    }
