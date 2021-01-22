    public string PersistanceKey
    {
        get { 
            if(ViewState["PersistanceKey"] == null)
               ViewState["PersistanceKey"] = "Object" + Guid.NewGuid().ToString();
            return (string)ViewState["PersistanceKey"];
        }
    }
    public PersistanceObject Persistance
    {
        get {
            if(Session[this.PersistanceKey] == null)
                Session[this.PersistanceKey] = new PersistanceObject();
            
            return (PersistanceObject)Session[this.PersistanceKey];
    }
