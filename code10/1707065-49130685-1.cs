    _fileTypeRegistry = new DocumentFileTypeRegistry();
    _fileTypeRegistry.RegisterType(new DocumentFileType());
    _fileTypeRegistry.RegisterType(new PhotoFileType());
    //retrieve the type by id
    var fileType = _fileTypeRegistry.GetTypeById(1);
