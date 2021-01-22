        public static IEnumerable<T> RandomPermutation<T>(this IEnumerable<T> sequence, int start,int end)
        {
            T[] array = sequence as T[] ?? sequence.ToArray();
            var result = new T[array.Length];
            for (int i = 0; i < start; i++)
            {
                result[i] = array[i];
            }
            for (int i = end; i < array.Length; i++)
            {
                result[i] = array[i];
            }
            var sortArray=new List<KeyValuePair<double,T>>(array.Length-start-(array.Length-end));
            lock (random)
            {
                for (int i = start; i < end; i++)
                {
                    sortArray.Add(new KeyValuePair<double, T>(random.NextDouble(), array[i]));
                }
            }
            sortArray.Sort((i,j)=>i.Key.CompareTo(j.Key));
            for (int i = start; i < end; i++)
            {
                result[i] = sortArray[i - start].Value;
            }
            return result;
        }
