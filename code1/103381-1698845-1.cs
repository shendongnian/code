        public class Pool<T> where T : class
        {
            private readonly Queue<AsyncResult<T>> asyncQueue = new Queue<AsyncResult<T>>();
            private readonly Func<T> createFunction;
            private readonly HashSet<T> pool;
            private readonly Action<T> resetFunction;
            public Pool(Func<T> createFunction, Action<T> resetFunction, int poolCapacity)
            {
                this.createFunction = createFunction;
                this.resetFunction = resetFunction;
                pool = new HashSet<T>();
                CreatePoolItems(poolCapacity);
            }
            public Pool(Func<T> createFunction, int poolCapacity) : this(createFunction, null, poolCapacity)
            {
            }
            public int Count
            {
                get
                {
                    return pool.Count;
                }
            }
            private void CreatePoolItems(int numItems)
            {
                for (var i = 0; i < numItems; i++)
                {
                    var item = createFunction();
                    pool.Add(item);
                }
            }
            public void Push(T item)
            {
                if (item == null)
                {
                    Console.WriteLine("Push-ing null item. ERROR");
                    throw new ArgumentNullException();
                }
                if (resetFunction != null)
                {
                    resetFunction(item);
                }
                lock (asyncQueue)
                {
                    if (asyncQueue.Count > 0)
                    {
                        var result = asyncQueue.Dequeue();
                        result.SetAsCompletedAsync(item);
                        return;
                    }
                }
                lock (pool)
                {
                    pool.Add(item);
                }
            }
            public T Pop()
            {
                T item;
                lock (pool)
                {
                    if (pool.Count == 0)
                    {
                        return null;
                    }
                    item = pool.First();
                    pool.Remove(item);
                }
                return item;
            }
            public IAsyncResult BeginPop(AsyncCallback callback)
            {
                var result = new AsyncResult<T>();
                result.AsyncCallback = callback;
                lock (pool)
                {
                    if (pool.Count == 0)
                    {
                        lock (asyncQueue)
                        {
                            asyncQueue.Enqueue(result);
                            return result;
                        }
                    }
                    var poppedItem = pool.First();
                    pool.Remove(poppedItem);
                    result.SetAsCompleted(poppedItem);
                    return result;
                }
            }
            public T EndPop(IAsyncResult asyncResult)
            {
                var result = (AsyncResult<T>) asyncResult;
                return result.EndInvoke();
            }
        }
