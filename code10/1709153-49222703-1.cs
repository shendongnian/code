    private static void AddGridData(string dataType)
    {
        var service = ServiceFactory.GetService(dataType);
        var data = service.GetData().ToList();
        grid.AddRange(data);
    }
