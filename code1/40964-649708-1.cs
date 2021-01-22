    ArrayObject _lastField;
    byte[] byteArray = new byte[]{2,1,2,3};
    object[] array = new object[byteArray.Length];
    byteArray.CopyTo(array, 0);
    _lastField = Microsoft.JScript.GlobalObject.Array.ConstructArray(array);
