    public int Property1 { get; set; }
    public bool Property2 { get; set; }
    public string Property3 { get; set; }
    public IEnumerable<object> Objects
    {
        get
        {
            yield return Property1;
            yield return Property2;
            yield return Property3;
        }
    }
