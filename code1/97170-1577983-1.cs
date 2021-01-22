    public class DomainObject<T, TRepo> 
         where T: DomainObject<T, TRepo> 
         where TRepo: IRepository<T, TRepo>
    {
         public static TRepo Repository
         {
             get;
             private set; 
         }
    }
    public interface IRepository<T, TRepo>
         where T: DomainObject<T, TRepo>
         where TRepo: IRepository<T, TRepo>
    {
         void Save(T domainObject);
    }
