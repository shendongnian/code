        public static void CopyToMultidimensionalArray(this IList<object> source, Array target, IList<int> dimensions)
        {
            var indices = new int[dimensions.Count];
            for (var i = 0; i < source.Count; i++)
            {
                var t = i;
                for (var j = indices.Length - 1; j >= 0; j--)
                {
                    indices[j] = t % dimensions[j];
                    t /= dimensions[j];
                }
                
                target.SetValue(source[i], indices);
            }
        }
