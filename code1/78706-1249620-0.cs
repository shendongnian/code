     public abstract class Repository<T> where T : class
     {
         public abstract T GetById( int id );
         public T SingleOrDefault( Func<int,T> selector )
         {
               return _dataContext.GetTable<T>().SingleOrDefault( selector );
         }
     }
