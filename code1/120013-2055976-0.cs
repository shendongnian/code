    public MyObj Clone()
        {
            BinaryFormatter bFormatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            bFormatter.Serialize(stream, this);
            stream.Seek(0, SeekOrigin.Begin);
            MyObj newObj = (MyObj)bFormatter.Deserialize(stream);
            return newObj;
        }
