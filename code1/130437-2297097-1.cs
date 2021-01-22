    public static byte[] EncryptByKey(SqlConnection connection,
        string keyName, string clearText)
    {
        return Execute<byte[]>(connection,
            string.Format("SELECT ENCRYPTBYKEY(KEY_GUID('{0}'), '{1}')"));
    }
