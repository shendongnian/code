    public abstract class Entity<T>
        {
            protected IRepository<Entity<T>> repository;
        
            public void Create()
            {
                repository.Create(this);//Error occurs here on this
            }
        }
