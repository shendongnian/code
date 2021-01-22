    public class TemporaryStorageService : ITemporaryStorageService
    {
        public void Deposit<T>(Object o, string key)
        {
            System.Windows.Application.Current.Properties[key] = o;
        }
        public T Withdraw<T>(string key)
        {   T o = (T)System.Windows.Application.Current.Properties[key];
            System.Windows.Application.Current.Properties.Remove(key);
            return o;
        }
    }
