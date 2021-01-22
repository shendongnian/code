     private object GetCopy(object original)
     {
         if (original == null)
         {
             return null;
         }
 
         object result;
         using (MemoryStream stream = new MemoryStream())
         {
             BinaryFormatter formatter = new BinaryFormatter();
             formatter.Serialize(stream, original);
             stream.Position = 0;
             result = formatter.Deserialize(stream);
             stream.Close();
         }
         return result;
     }
