    abstract class DataMapper
    {
        abstract public object Map(IDataReader);
    }
    class BookMapper : DataMapper
    {
       override public object Map(IDataReader reader)
       {
           ///some mapping stuff
           return book;
       }
    }
    public class Mapper<T>
    {
        public static List<T> MapObject(IDataReader dr)
        {
            List<T> objects = new List<T>();
            DataMapper myMapper = getMapperFor(T);
            while (dr.Read())
            {
                objects.Add((T)myMapper(dr));
            }
            return objects;
        }
        
        private DataMapper getMapperFor(T myType)
        {
           //switch case or if or whatever
           ...
           if(T is Book) return bookMapper;
        }
    }
