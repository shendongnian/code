    public List<String> GetFiles(string path)
    {
        using (SftpClient client = new SftpClient( _host, _port, _username, _password ) )
        {
            client.Connect();
            return client
                .ListDirectory( path )
                .Where( f => !f.IsDirectory )
                .Select( f => f.Name )
                .ToList();
        }
    }
    public List<String> GetDirectories(string path)
    {
        using (SftpClient client = new SftpClient( _host, _port, _username, _password ) )
        {
            client.Connect();
            return client
                .ListDirectory( path )
                .Where( f => f.IsDirectory )
                .Select( f => f.Name )
                .ToList();
        }
    }
