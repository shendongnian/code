        public static string GetXMLStringFromDataContract(object contractEntity)
        {
            using (System.IO.MemoryStream writer = new System.IO.MemoryStream())
            {
                var dataContractSerializer = new DataContractSerializer(contractEntity.GetType());
                dataContractSerializer.WriteObject(writer, contractEntity);
                writer.Position = 0;
                var streamReader = new System.IO.StreamReader(writer);
                return streamReader.ReadToEnd();
            }
        }
