        /// <summary>
        /// Takes an item from the <see cref="FastBlockingCollection{T}"/>
        /// </summary>
        public T Take(CancellationToken token)
        {
            T item;
            while (!queue.TryDequeue(out item))
            {
                waitHandle.WaitOne(cancellationCheckTimeout); // can be 10-100 ms
                token.ThrowIfCancellationRequested();
            }
            return item;
        }
