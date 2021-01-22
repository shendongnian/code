        public Pool(int size, Func<Pool<T>, T> factory,
            LoadingMode loadingMode, AccessMode accessMode)
        {
            if (size <= 0)
                throw new ArgumentOutOfRangeException("size", size,
                    "Argument 'size' must be greater than zero.");
            if (factory == null)
                throw new ArgumentNullException("factory");
            this.size = size;
            this.factory = factory;
            sync = new Semaphore(size, size);
            this.loadingMode = loadingMode;
            this.itemStore = CreateItemStore(accessMode, size);
            if (loadingMode == LoadingMode.Eager)
            {
                PreloadItems();
            }
        }
