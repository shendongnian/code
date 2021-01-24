    private TableDef _parent;
    public TableDef Parent {
        get { return _parent; }
        set {
            this._parent = value;
            ID = Parent.Name.Replace(" ", "") + "_" + Name.Replace(" ", "");
        }
    } 
