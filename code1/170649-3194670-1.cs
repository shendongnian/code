     abstract class Store<TEntity>
    {
         abstract TEntity Get(object identifier);
         protected abstract void Put(TEntity entity);
         void PutBase(TEntity entity)
         {
             Put(entity);
             //Raise event here
         }
    }
