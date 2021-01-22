        public T Acquire()
        {
            sync.WaitOne();
            switch (loadingMode)
            {
                case LoadingMode.Eager:
                    return AcquireEager();
                case LoadingMode.Lazy:
                    return AcquireLazy();
                default:
                    Debug.Assert(loadingMode == LoadingMode.LazyExpanding,
                        "Unknown LoadingMode encountered in Acquire method.");
                    return AcquireLazyExpanding();
            }
        }
        public void Release(T item)
        {
            lock (itemStore)
            {
                itemStore.Store(item);
            }
            sync.Release();
        }
