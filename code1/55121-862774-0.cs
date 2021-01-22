    [DllImport("crypt.dll", CharSet=CharSet.ASCII)]
    private static extern string crypt(string password, string salt);
    public bool ValidLogin(string username, string password)
    {
        string hash = crypt(password, null);
        ...
    }
