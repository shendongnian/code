    static class VectorExtension
    {
        public static Vector<double> Differentiate(this Vector<double> vector)
        {
            var high = Vector<double>.Build.DenseOfEnumerable(vector.Skip(1));
            var low = Vector<double>.Build.DenseOfEnumerable(vector.Take(vector.Count - 1));
            return  high - low;
        }
    }
