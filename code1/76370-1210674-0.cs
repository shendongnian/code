                    IsolatedStorageFile isolatedStorage = IsolatedStorageFile.GetUserStoreForAssembly();
                using (IsolatedStorageFileStream stream = new
                    IsolatedStorageFileStream(key, FileMode.Create, isolatedStorage))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(stream, value);
                }
