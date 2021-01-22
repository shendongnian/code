        public static IEnumerable<IEnumerable<T>> GetBatches<T>(this IEnumerable<T> items, int batchsize) {
            var itemsCopy = items;
            while (itemsCopy.Any()) {
                yield return itemsCopy.Take(batchsize);
                itemsCopy = itemsCopy.Skip(batchsize);
            }
        }
