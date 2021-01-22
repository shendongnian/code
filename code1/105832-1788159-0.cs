    public class LazyProperty<TEntityType> where TEntityType : class
    {
        private readonly IQueryable<TEntityType> source;
        private bool loaded;
        private TEntityType entity;
        public LazyProperty()
        {
            loaded = true;
        }
        public LazyProperty(IQueryable<TEntityType> source)
        {
            this.source = source;
        }
        public TEntityType Entity
        {
            get 
            {
                if (!loaded)
                {
                    entity = source.SingleOrDefault();
                    loaded = true;
                }
                return entity;
            }
            set 
            { 
                entity = value;
                loaded = true;
            }
        }
    }
