    public IEnumerable<KeyValuePair<DateTime?, string>> ResultObjects { get; set; }
    public DateTime? SelectedObject { get; set; }
    ...
    ResultObjects = new List<KeyValuePair<DateTime?, string>>()
    {
        new KeyValuePair<DateTime?, string>(null, "All"),
        new KeyValuePair<DateTime?, string>(new DateTime(2018,04,17), new DateTime(2018,04,17).ToString("yyyy/MM/dd")),
        new KeyValuePair<DateTime?, string>(new DateTime(2018,04,17), new DateTime(2018,04,17).ToString("yyyy/MM/dd @ HH:mm:ss")),
        new KeyValuePair<DateTime?, string>(new DateTime(2018,04,17), "Custom...")
    };
    ...
