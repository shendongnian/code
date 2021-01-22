    public interface IUserDataStorage<T>
    {
       T Access { get; set; }
    }
    
    public class HttpUserDataStorage<T>: IUserDataStorage<T>
      where T : class
    {
      public T Access
      {
         get { return HttpContext.Current.Session[typeof(T).FullName] as T; }
         set { HttpContext.Current.Session[typeof(T).FullName] = value; }
      }
    }
