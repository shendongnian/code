        public T deserialize<T>(Stream str) where T : class, new()
        {
            Type type = typeof(T);
            if (type == typeof(GZipStream))
            {
                var t = new GZipStream(str, CompressionMode.Compress, true);
                return t as T;
            }
            else
            {
                BinaryFormatter bin = new BinaryFormatter();
                return (T)bin.Deserialize(str);
            }
        }
