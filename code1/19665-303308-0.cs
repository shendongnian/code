        public string SerializeObject<T>(T objectToSerialize)
        {
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream memStr = new MemoryStream();
            try
            {
                bf.Serialize(memStr, objectToSerialize);
                memStr.Position = 0;
                return Convert.ToBase64String(memStr.ToArray());
            }
            finally
            {
                memStr.Close();
            }
        }
