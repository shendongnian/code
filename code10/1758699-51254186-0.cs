    private TableDef _parent;
    public TableDef Parent {
            get { return _parent; }
            set {
                this._parent = value;
                ID = this._parent.Name.Replace(" ", "") + "_" + Name.Replace(" ", "");
            }
        }  
