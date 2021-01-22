    /// <summary>
    /// Is this a new object
    /// </summary>
    public bool IsNew
    {
        get
        {
            // initial value
            bool isNew = (this.CustomerID > 0);
            // return value
            return isNew;
        }
    }
