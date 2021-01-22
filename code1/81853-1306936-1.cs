    public class YourClass 
    {
        public object Clone()
        {
            using (var ms = new MemoryStream())
            {
               var bf = new BinaryFormatter();
               bf.Serialize(ms, this);
               ms.Position = 0;
               object obj = bf.Deserialize(ms);
               ms.Close();
               return obj;
            }
        }
    }
