        public static Array RemoveAt(Array source, int index)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (0 > index || index >= source.Length)
                throw new ArgumentOutOfRangeException("index", index, "index is outside the bounds of source array");
            Array dest = Array.CreateInstance(source.GetType().GetElementType(), source.Length - 1);
            Array.ConstrainedCopy(source, 0, dest, 0, index);
            Array.ConstrainedCopy(source, index + 1, dest, index, source.Length - index - 1);
            
            return dest;
        }
