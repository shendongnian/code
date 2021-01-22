    public static char[] RemoveBackslash(string value)
    {
        char[] c = value.ToCharArray();
        return Array.FindAll(c, val => val != 39).ToArray();
    }
    string content = "'\"online\" and \"text\"'";
    
    Sqlparam = new SqlParameter("@search", SqlDbType.NVarChar);
    Sqlparam.Value = RemoveBackslash(content);
    Sqlcomm.Parameters.Add(Sqlparam);
