        private int size;
        private int count;
        private T AcquireEager()
        {
            lock (itemStore)
            {
                return itemStore.Fetch();
            }
        }
        private T AcquireLazy()
        {
            lock (itemStore)
            {
                if (itemStore.Count > 0)
                {
                    return itemStore.Fetch();
                }
            }
            Interlocked.Increment(ref count);
            return factory(this);
        }
        private T AcquireLazyExpanding()
        {
            bool shouldExpand = false;
            if (count < size)
            {
                int newCount = Interlocked.Increment(ref count);
                if (newCount <= size)
                {
                    shouldExpand = true;
                }
                else
                {
                    // Another thread took the last spot - use the store instead
                    Interlocked.Decrement(ref count);
                }
            }
            if (shouldExpand)
            {
                return factory(this);
            }
            else
            {
                lock (itemStore)
                {
                    return itemStore.Fetch();
                }
            }
        }
        private void PreloadItems()
        {
            for (int i = 0; i < size; i++)
            {
                T item = factory(this);
                itemStore.Store(item);
            }
            count = size;
        }
