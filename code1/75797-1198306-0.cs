     public object Clone()
     {
         DataContractSerializer serializer = new DataContractSerializer(this.GetType());
         using (MemoryStream memStream = new MemoryStream())
         {
             serializer.WriteObject(memStream, this);
             memStream.Position = 0;
             return serializer.ReadObject(memStream);
         }
      }
