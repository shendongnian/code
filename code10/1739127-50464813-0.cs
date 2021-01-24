    public static class ListExtentions
    {
        public static void AddOrUpdate<T>(this List<T> that, int index, T value)
        {
            if (that.Count > index)
            {
                that[index] = value;
            }
            else
            {
                that.Add(value);
            }
        }
    }
