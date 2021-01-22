    ...
    public IEnumerable<string> MySelectList { get; set; }
    public EventRegistreerViewModel() {
        // build the select the list as selectList, then
        this.MySelectList = selectList;
    }
