    ProcessList(clientList.Select(x => new { x.FullName }));
    ...
    public void ProcessList<T>(IEnumerable<T> list)
    {
        // process list ... T will be an anonymous type by now
        grid.DataSource = list;
    }
