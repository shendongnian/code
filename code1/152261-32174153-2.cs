    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void SaveFileToLocalDiskStreamed(
        [SqlFacet(MaxSize = -1)] SqlBytes FileContents, SqlString DestinationPath)
    {
        if (FileContents.IsNull || DestinationPath.IsNull)
        {
            throw new ArgumentException("Seriously?");
        }
        int _ChunkSize = 1024;
        byte[] _Buffer = new byte[_ChunkSize];
        using (FileStream _File = new FileStream(DestinationPath.Value, FileMode.Create))
        {
            long _Position = 0;
            long _BytesRead = 0;
            while (true)
            {
                _BytesRead = FileContents.Read(_Position, _Buffer, 0, _ChunkSize);
                _File.Write(_Buffer, 0, (int)_BytesRead);
                _Position += _ChunkSize;
                if (_BytesRead < _ChunkSize || (_Position >= FileContents.Length))
                {
                    break;
                }
            }
            _File.Close();
        }
        return;
    }
