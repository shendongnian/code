    public class ShuffleArranger<T> : IArranger<T>
    {
        private Random r = new Random();
        //naive implementation for demonstration
        //if I ever develop this more completely I would try to avoid needing to call .ToArray() in here
        public IEnumerable<T> Arrange(IEnumerable<T> items)
        {
            var values = items.ToArray();
            
            for (int i = values.Length; i > 1; i--)
            {
                int j = r.Next(i);
                T tmp = values[j];
                values[j] = values[i - 1];
                values[i - 1] = tmp;
            }
            foreach (var item in values) yield return item;
        }
    }
