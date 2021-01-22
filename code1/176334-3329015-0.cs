    object[] primitiveData = new object[byteData.Lenght];
    for (int i = 0; i < bytesData.Lenght; i++)
    {
         primitiveData[i] = Converter.ChangeType(bytesData[i], types[i]);
    }
