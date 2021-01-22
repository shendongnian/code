        public static void CopyToMultidimensionArray(IList<int> dimensions, Array target, IList<object> source)
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
