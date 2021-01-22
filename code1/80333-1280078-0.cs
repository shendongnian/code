        public void Add(TKey key, TValue value)
        {
            if (key == null)
            {
                System.ThrowHelper.ThrowArgumentNullException(System.ExceptionArgument.key);
            }
            int num = Array.BinarySearch<TKey>(this.keys, 0, this._size, key, this.comparer);
            if (num >= 0)
            {
                System.ThrowHelper.ThrowArgumentException(System.ExceptionResource.Argument_AddingDuplicate);
            }
            this.Insert(~num, key, value);
        }
