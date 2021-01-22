    static class ListExtension
    {
        public static List<List<T>> BreakIntoChunks<T>(this List<T> list, int chunkSize)
        {
            if (chunkSize <= 0)
            {
                throw new ArgumentException("chunkSize must be greater than 0.");
            }
            List<List<T>> retVal = new List<List<T>>();
            while (list.Count > 0)
            {
                int count = list.Count > chunkSize ? chunkSize : list.Count;
                retVal.Add(list.GetRange(0, count));
                list.RemoveRange(0, count);
            }
            return retVal;
        }
    }
