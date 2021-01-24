    dbx = dbx.WithPathRoot(new PathRoot.NamespaceId(accountInfo.RootInfo.RootNamespaceId));
    var res = await this.client.Files.ListFolderAsync(path: "");
    foreach (var entry in res.Entries)
    {
        Console.WriteLine(entry.Name);
    }
