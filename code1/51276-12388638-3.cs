    public void CompareTwoObjects()
    {
        try {   
            byte[] btArray = ObjectToByteArray(object1);   //object1 is you custom object1
            byte[] btArray2 = ObjectToByteArray(object2); //object2 is you custom object2
            bool result = ByteArrayCompare(btArray, btArray2);
        } catch (Exception ex) {
            throw ex;
        }
    }
    public byte[] ObjectToByteArray(object _Object)
    {
        try {
            // create new memory stream
            System.IO.MemoryStream _MemoryStream = new System.IO.MemoryStream();
            // create new BinaryFormatter
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter _BinaryFormatter
                = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            // Serializes an object, or graph of connected objects, to the given stream.
            _BinaryFormatter.Serialize(_MemoryStream, _Object);
            // convert stream to byte array and return
            return _MemoryStream.ToArray();
        } catch (Exception _Exception) {
            // Error
            Console.WriteLine("Exception caught in process: {0}", _Exception.ToString());
        }
        // Error occured, return null
        return null;
    }
    public bool ByteArrayCompare(byte[] a1, byte[] a2)
    {
        if (a1.Length != a2.Length)
            return false;
        for (int i = 0; i < a1.Length; i++)
            if (a1[i] != a2[i])
                return false;
        return true;
    }
