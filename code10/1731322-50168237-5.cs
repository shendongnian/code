        public T deserialize<T>(Stream str) where T : class, new()
        {
            Type type = typeof(T);
            if (type == typeof(Stream))
            {
                using (var bigStr = new GZipStream(str, CompressionMode.Decompress))
                using (var outStream = new MemoryStream())
                {
                    bigStr.CopyTo(outStream);
                    return outStream as T;
                }
            }
            else
            {
                BinaryFormatter bin = new BinaryFormatter();
                return (T)bin.Deserialize(str);
            }
        }
