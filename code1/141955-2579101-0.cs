    [PersistenceMode(PersistenceMode.Attribute)]
    public string Status
        {
            get
            {
                object o = ViewState["Status"];
                if(o != null) {
                    return (string)o;
                }
                return string.Empty;
            }
            set
            {
                ViewState["Status"] = value;
            }
        }
