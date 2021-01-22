    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void SaveFileToLocalDisk([SqlFacet(MaxSize = -1)] SqlBytes FileContents,
        SqlString DestinationPath)
    {
        if (FileContents.IsNull || DestinationPath.IsNull)
        {
            throw new ArgumentException("Seriously?");
        }
        File.WriteAllBytes(DestinationPath.Value, FileContents.Buffer);
        return;
    }
