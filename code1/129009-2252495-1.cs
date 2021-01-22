    [PersistenceMode(PersistenceMode.InnerProperty)]
    public TestData TestProperty {
        get {
            return ViewState["TestProperty"] as TestData;
        }
        set {
            ViewState["TestProperty"] = value;
        }
    }
    
