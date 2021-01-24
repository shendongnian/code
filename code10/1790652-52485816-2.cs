    public static bool FileHasChanged { get; set; }
    ...
    var xmlserializer = new XmlSerializer(typeof(MyFile));
    using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite)) {
        xmlserializer.Serialize(fs, this);
    }
    FileHasChanged = true;
