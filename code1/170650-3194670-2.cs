     abstract class Store<TEntity>
    {
         public abstract TEntity Get(object identifier);
         protected abstract void Put(TEntity entity);
         public void PutBase(TEntity entity)
         {
             Put(entity);
             //Raise event here
         }
    }
