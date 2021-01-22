        Object lstfinal = new Object();
        using (MemoryStream memStream = new MemoryStream())
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter(null, new StreamingContext(StreamingContextStates.Clone));
            binaryFormatter.Serialize(memStream, objtype); memStream.Seek(0, SeekOrigin.Begin);
            lstfinal = binaryFormatter.Deserialize(memStream);
        }
        return lstfinal;
    }
