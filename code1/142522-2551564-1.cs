    /// <summary>
    /// Default Text property ("inner text" in HTML/Markup)
    /// </summary>
    [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
    public string PropertyTest
    {
        get
        {
            object o = this.ViewState["Text"];
            if (o != null)
            {
                return (string)o;
            }
            return string.Empty;
        }
        set
        {
            this.ViewState["Text"] = value;
        }
    }
