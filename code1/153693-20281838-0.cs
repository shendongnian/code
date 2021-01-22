    public class OneBasedArray<T>
    {
        Array innerArray;
        public OneBasedArray(params int[] lengths)
        {
            innerArray = Array.CreateInstance(typeof(T), lengths, Enumerable.Repeat<int>(1, lengths.Length).ToArray());
        }
        public T this[params int[] i]
        {
            get
            {
                return (T)innerArray.GetValue(i);
            }
            set
            {
                innerArray.SetValue(value, i);
            }
        }
    }
