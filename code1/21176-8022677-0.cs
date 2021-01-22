        public object GetDefault(Type t)
        {
            return this.GetType().GetMethod("GetDefaultGeneric").MakeGenericMethod(CurrentType).Invoke(this, null);
        }
        public T GetDefaultGeneric<T>()
        {
            return default(T);
        }
