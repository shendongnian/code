    public object ImportantProperty 
    {
        get
        {
            if (!this.DesignMode && _superImportantProperty == null)
            {
                throw new Exception("The property ImportantProperty must be set.");
            }
        }
    }
