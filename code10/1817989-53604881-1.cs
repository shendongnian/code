    public byte[] ProcessData(List<MyData> inData, string fieldName)
    {          
        var field = inData.GetType().GetField(fieldName);
        if (field == null)
              throw new ArgumentException("Invalid field name", nameof(fieldName));
          
        byte[] bytesField = field.GetValue(inData) as byte[];
        var byteArray = new byte[bytesField.Sum().Length];
        var offset = 0;
        for (int i = 0; i < inData.Count; i++) {
            Buffer.BlockCopy(bytesField[i], 0, ret, offset, bytesField.Length);
            offset += bytesField.Length;
        }
    
        return byteArray;
    }
