        public static IEnumerable<IEnumerable<T>> InBatchesOf<T>(this IEnumerable<T> items, int batchSize)
        {
            List<T> batch = new List<T>(batchSize);
            foreach (var item in items)
            {
                batch.Add(item);
                if (batch.Count >= batchSize)
                {
                    yield return batch;
                    batch = new List<T>();
                }
            }
            if (batch.Count != 0)
            {
                //can't be batch size or would've yielded above
                batch.TrimExcess();
                yield return batch;
            }
        }
