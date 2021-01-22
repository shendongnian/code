    [ThreadStatic]
    private static BinaryFormatter formatter = null;
    public static T DeepClone<T>(this T a)
        {
                if( formatter == null ) formatter = new BinaryFormatter();
                using(MemoryStream stream = new MemoryStream())
                {
                        formatter.Serialize(stream, a);
                        stream.Position = 0;
                        return (T)formatter.Deserialize(stream);
                }
        }
