    [XmlElement("name")]
    public MyText Name
    {
        get { return GetProperty(() => Name); }
        set { SetProperty(() => Name, value); }
    }
