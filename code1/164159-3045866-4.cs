    public class SampleIsolatedStorageManager : IDisposable
    {
        private string filename;
        private string directoryname;
        IsolatedStorageFile isf;
        public SampleIsolatedStorageManager()
        {
            filename = string.Empty;
            directoryname = string.Empty;
            // create an ISF scoped to domain user...
            isf = IsolatedStorageFile.GetStore(IsolatedStorageScope.User |
                IsolatedStorageScope.Assembly | IsolatedStorageScope.Domain,
                typeof(System.Security.Policy.Url), typeof(System.Security.Policy.Url));
        }
        public void Save<T>(T parm)
        {
            using (IsolatedStorageFileStream stm = GetStreamByStoredType<T>(FileMode.Create))
            {
                SampleDataSerializer.Serialize<T>(parm, stm);
            }
        }
        public T Restore<T>() where T : new()
        {
            try
            {
                if (GetFileNameByType<T>().Length > 0)
                {
                    T result = new T();
                    using (IsolatedStorageFileStream stm = GetStreamByStoredType<T>(FileMode.Open))
                    {
                        SampleDataSerializer.Deserialize<T>(out result, stm);
                    }
                    return result;
                }
                else
                {
                    return default(T);
                }
            }
            catch
            {
                try
                {
                    Clear<T>();
                }
                catch
                {
                }
                return default(T);
            }
        }
        public void Clear<T>()
        {
            if (isf.GetFileNames(GetFileNameByType<T>()).Length > 0)
            {
                isf.DeleteFile(GetFileNameByType<T>());
            }
        }
        private string GetFileNameByType<T>()
        {
            return typeof(T).Name + ".cache";
        }
        private IsolatedStorageFileStream GetStreamByStoredType<T>(FileMode mode)
        {
            var stm = new IsolatedStorageFileStream(GetFileNameByType<T>(), mode, isf);
            return stm;
        }
        #region IDisposable Members
        public void Dispose()
        {
            isf.Close();
        }
    }
