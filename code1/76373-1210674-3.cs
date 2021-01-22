    using (IsolatedStorageFile isolatedStorage = 
         IsolatedStorageFile.GetUserStoreForAssembly())
    {
        using (IsolatedStorageFileStream stream = 
          new IsolatedStorageFileStream(
             key, FileMode.OpenOrCreate, FileAccess.ReadWrite, isolatedStorage))
        {
            if (stream.Length > 0)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(stream);
            }
            else
            {
                return default(T);
            }
    
        }
    }
