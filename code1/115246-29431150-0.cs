    public static List<T> CopyList<T>(this List<T> lst)
        {
            List<T> lstCopy = new List<T>();
            foreach (var item in lst)
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, item);
                    stream.Position = 0;
                    lstCopy.Add((T)formatter.Deserialize(stream));
                }
            }
            return lstCopy;
        }
