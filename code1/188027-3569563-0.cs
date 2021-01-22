    var versions = new List<MyViewModel>();
    var dataProvider = TryFindResource("versionsXml") as XmlDataProvider;
    if (null == dataProvider)
    {
        return versions;
    }
    var nodes = dataProvider.Data as IEnumerable;
    if (null == nodes)
    {
        return versions;
    }
    foreach (XmlElement node in nodes)
    {
       ...
    }
