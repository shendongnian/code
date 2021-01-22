    public class EntityCollectionBase<T> where T : EntityBase
    {
        public void Load()
        {
            var constructorInfo = typeof(T).GetConstructor(new[] { typeof(IDataReader) });
            using(IDataReader reader = ...)
            {
                while(reader.Read())
                {
                    T entity = (T)constructorInfo.Invoke(new object[] { reader });
                    this.Add(entity);
                }
            }
        }
    }
