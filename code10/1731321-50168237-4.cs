    public T Deserialize<T>(Stream str)
        {
            Type type = typeof(T);
            if (type == typeof(Stream))
            {
                using (var bigStr = new GZipStream(str, CompressionMode.Decompress))
                using (var outStream = new MemoryStream())
                {
                    bigStr.CopyTo(outStream);
                    return (T)(outStream as object);
                }
            }
            else
            {
                BinaryFormatter bin = new BinaryFormatter();
                return (T)bin.Deserialize(str);
            }
        }
