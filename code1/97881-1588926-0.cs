    public static IWorkerDocument Create<T>(IFileSystem fileSystem, IDocumentLibraryUser user) where T : IWorkerDocument
    {
        var documentType = typeof(T);
        if (documentType == typeof(Contract))
            return new Contract(fileSystem, user);
        if (documentType == typeof(Assignment))
            return new Assignment(fileSystem, user);
        throw new Exception("Invalid Document Type");
     }
