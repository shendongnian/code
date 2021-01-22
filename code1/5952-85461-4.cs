    public interface IPrimaryKey<T> where T : IPrimaryKey<T>
    {
        int Id { get; }
    }
    public static class IPrimaryKeyTExtension
    {
         public static IPrimaryKey<T> GetById<T>(this IQueryable<T> source, int id) where T : IPrimaryKey<T>
         {
             return source.Where(pk => pk.Id == id).SingleOrDefault();
         }
    }
    public class Person : IPrimaryKey<Person>
    {
        public int Id { get; set; }
    }
