    static void SetValue2(this Array a, object value, int i) {
        int[] indices = new int[a.Rank];
        for (int d = a.Rank - 1; d >= 0; d--) {
            var l = a.GetLength(d);
            indices[d] = i % l;
            i /= l
        }
        a.SetValue(value, indices);
    }
