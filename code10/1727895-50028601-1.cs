    public string Description{ get; set; }
    public int Category { get; set; }
    //Change this back to string, since that is what your JSON is
    public string Target{ get; set; }
    //Add a "TargetList" property that just reads from "Target" and turns into a List
    public List<int> TargetList => Target.Split(',').Select(x => int.Parse(x)).ToList();
