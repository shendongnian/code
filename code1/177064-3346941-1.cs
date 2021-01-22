    interface IDataHolder
    {
        IEntity Entity { get; set;  }
        IData Data { get;  set;  }
    }
    class DataHolder<T,T1> : IDataHolder
        where T : class, IEntity
        where T1 : class, IData
    {
        T entity;
        T1 data;
        public DataHolder(T entity, T1 data)
        {
            this.entity = entity;
            this.data = data;
        }
        public T Entity { get { return entity; } set { entity = value; } }
        public T1 Data { get { return data; } set { data = value; } }
        IEntity IDataHolder.Entity
        {
            get { return entity; }
            set { entity = value as T; }
        }
        IData IDataHolder.Data
        {
            get { return data; }
            set { data = value as T1; }
        }
    }
