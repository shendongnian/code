    var ids = new List<string>();
    using (StreamReader sr = new StreamReader($@"{File}"))
    {
        var id = sr.ReadLine();
        while (id != null)
        {
            ids.Add(id);
            id = sr.ReadLine();
        }
    }
    Parallel.ForEach(ids, (id) => ConnectToServiceAndDump(client, id, outputSubdirectoryName));
